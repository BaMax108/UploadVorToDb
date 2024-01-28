using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using UploadVorToDb.Domain.Interfaces;
using UploadVorToDb.VorApplication.UseCasaes.Builder;

namespace UploadVorToDb.VorApplication.Repositories
{
    /// <summary></summary>
    public struct MainCollection
    {
        /// <summary></summary>
        public static ObservableCollection<IUiRecord> RecordDataCollection { get; private set; }

        static MainCollection()
        {
            RecordDataCollection = new ObservableCollection<IUiRecord>();
            RecordDataCollection.CollectionChanged += OnCollectionChanged;
        }

        /// <summary></summary>
        public static void AddRecord(IUiRecord arg)
        {
            arg.Id = RecordDataCollection.Count + 1;
            RecordDataCollection.Add(arg);
        }

        /// <summary>
        /// Фильтрация на основе существующей структуры данных TasksRepository.TasksDictionary
        /// </summary>
        /// <param name="xlsxCollection"></param>
        public static void AddRecords(ICollection<IUiRecord> xlsxCollection)
        {
            string tempTypeName, tempTemp, tempI;
            
            List<IElementFields> elementsList;
            dynamic coll = new StructureBuilder().Repository;
            dynamic tasks2, chapters2, bParts2;
            
            // ["TaskName"]["DisciplineTo"]["DisciplineFrom"]["BuiltPart"]
            foreach (IUiRecord xlsxRecord in xlsxCollection)
            {
                if (!coll.ContainsKey(xlsxRecord.WorkNameShort)) continue;
                tasks2 = coll[xlsxRecord.WorkNameShort];

                if (!tasks2.ContainsKey(xlsxRecord.Chapter)) continue;
                chapters2 = tasks2[xlsxRecord.Chapter];

                if (!chapters2.ContainsKey(xlsxRecord.Discipline)) continue;
                bParts2 = chapters2[xlsxRecord.Discipline];

                if (!bParts2.ContainsKey(xlsxRecord.BuildingPart)) continue;
                elementsList = bParts2[xlsxRecord.BuildingPart];

                if (elementsList == null || elementsList.Count == 0) return;

                xlsxRecord.Id = RecordDataCollection.Count + 1;
                tempTypeName = xlsxRecord.WorkNameFull;
                xlsxRecord.WorkNameFull = "";
                
                foreach (IElementFields i in elementsList)
                {
                    tempTemp = Replace(tempTypeName);
                    tempI = Replace(i.TaskName);
                    
                    if (tempTemp.StartsWith(tempI))
                    { 
                        if (i.Chapter == xlsxRecord.Chapter &
                            i.Discipline == xlsxRecord.Discipline &
                            i.BuildingPart == xlsxRecord.BuildingPart)
                        {
                            xlsxRecord.Assignment = i.Assignment;
                            xlsxRecord.StandardType = i.StandardType;
                            xlsxRecord.WorkNameFull = tempTypeName;
                            RecordDataCollection.Add(xlsxRecord);
                            break;
                        }
                    }
                }
            }
        }

        private static string Replace(string value)
        {
            StringBuilder sp = new StringBuilder();
            
            foreach (char c in value) 
            {
                if (char.IsLetterOrDigit(c))
                {
                    if (char.IsUpper(c))
                    {
                        sp.Append(char.ToLower(c));
                    }
                    else 
                    { 
                        sp.Append(c);
                    }
                }
            }

            return sp.ToString();
        }

        /// <summary></summary>
        public static void Edit(IUiRecord record, IList<IUiRecord> records)
        {
            int index;
            foreach (IUiRecord r in records) 
            {
                index = r.Id - 1;
                if (record.WorkNameShort != null)
                    RecordDataCollection[index].WorkNameShort = record.WorkNameShort;

                if (record.Discipline != null)
                    RecordDataCollection[index].Discipline = record.Discipline;

                if (record.Chapter != null)
                    RecordDataCollection[index].Chapter = record.Chapter;

                if (record.BuildingPart != null)
                    RecordDataCollection[index].BuildingPart = record.BuildingPart;

                if (record.WorkNameFull != null)
                    RecordDataCollection[index].WorkNameFull = record.WorkNameFull;

                if (record.Section != null)
                    RecordDataCollection[index].Section = record.Section;

                if (record.Discription != null)
                    RecordDataCollection[index].Discription = record.Discription;

                if (record.Units != null)
                    RecordDataCollection[index].Units = record.Units;

                if (record.Count > 0)
                    RecordDataCollection[index].Count = record.Count;

                RecordDataCollection[index].ExportBy = Domain.Enums.ExportTypes.ByUser;
            }
        }

        /// <summary></summary>
        /// <param name="items"></param>
        public static void Delete(IList<IUiRecord> items)
        {
            foreach (IUiRecord i in items.OfType<IUiRecord>().ToList())
                RecordDataCollection.Remove(i);

            if (RecordDataCollection.Count > 0)
            { 
                for (int i = 0; i < RecordDataCollection.Count; i++)
                {
                    RecordDataCollection[i].Id = i + 1;
                }
            }
        }

        #region Notify Collection Changed Event
        private static void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            List<IUiRecord> editedOrRemovedItems = new List<IUiRecord>();
            if (e.NewItems != null)
                foreach (IUiRecord newItem in e.NewItems)
                    editedOrRemovedItems.Add(newItem);

            if (e.OldItems != null)
                foreach (IUiRecord oldItem in e.OldItems)
                    editedOrRemovedItems.Add(oldItem);
        }
        #endregion
    }
}

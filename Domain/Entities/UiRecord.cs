using UploadVorToDb.Domain.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UploadVorToDb.Domain.Enums;

namespace UploadVorToDb.Domain.Entities
{
    /// <summary>Тип, содержащий данные для отображения в пользовательском интерфейсе.</summary>
     public class UiRecord : IUiRecord, INotifyPropertyChanged
    {
        /// <summary></summary>
        public ExportTypes ExportBy { get; set; }

        /// <summary>Уникальный идентификатор.</summary>
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }
        private int _id;

        /// <summary>Наименование задания.</summary>
        public string WorkNameShort
        {
            get => _workNameShort;
            set
            {
                _workNameShort = value;
                OnPropertyChanged();
            }
        }
        private string _workNameShort;

        /// <summary>Раздел, передающий задание.</summary>
        public string Discipline
        {
            get => _discipline;
            set
            {
                _discipline = value;
                OnPropertyChanged();
            }
        }
        private string _discipline;

        /// <summary>Раздел, которому передается задание.</summary>
        public string Chapter
        {
            get => _chapter;
            set
            {
                _chapter = value;
                OnPropertyChanged();
            }
        }
        private string _chapter;

        /// <summary>Функциональная часть здания.</summary>
        public string BuildingPart
        {
            get => _buildingPart;
            set
            {
                _buildingPart = value;
                OnPropertyChanged();
            }
        }
        private string _buildingPart;

        /// <summary>Наименование вида работ.</summary>
        public string WorkNameFull
        {
            get => _workNameFull;
            set
            {
                _workNameFull = value;
                OnPropertyChanged();
            }
        }
        private string _workNameFull;

        /// <summary>CGN_Стандарт_Тип.</summary>
        public string StandardType
        {
            get => _standardType;
            set
            {
                _standardType = value;
                OnPropertyChanged();
            }
        }
        private string _standardType;

        /// <summary>CGN_ВОР_Назначение.</summary>
        public string Assignment
        {
            get => _assignment;
            set
            {
                _assignment = value;
                OnPropertyChanged();
            }
        }
        private string _assignment;

        /// <summary>CGN_Секция.</summary>
        public string Section
        {
            get => _section;
            set
            {
                _section = value;
                OnPropertyChanged();
            }
        }
        private string _section;

        /// <summary>CGN_Описание.</summary>
        public string Discription
        {
            get => _discription;
            set
            {
                _discription = value;
                OnPropertyChanged();
            }
        }
        private string _discription;

        /// <summary>ADSK_Единица измерения.</summary>
        public string Units
        {
            get => _units;
            set
            {
                _units = value;
                OnPropertyChanged();
            }
        }
        private string _units;
        
        /// <summary>ADSK_Количество.</summary>
        public decimal Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged();
            }
        }
        private decimal _count;

        /// <summary>Событие, возникающее при изменении свойства компонента.</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>Обработка изменения.</summary>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using UploadVorToDb.UI.Interfaces;
using System.Linq;
using System;
using System.Windows.Input;
using UploadVorToDb.Domain.Interfaces;
using UploadVorToDb.Domain.Entities;
using UploadVorToDb.VorApplication.UseCasaes.Builder;

namespace UploadVorToDb.UI.Views
{
    /// <summary>
    /// Логика взаимодействия для CreateRecordWindow.xaml
    /// </summary>
    public partial class CreateRecordWindow : Window
    {
        private IUiRecord CurrentRecord;
        private readonly List<IUiRecord> SelectedItems;
        private readonly IRecordsController Controller;
        private readonly bool IsCreateWindow = false;

        private List<IElementFields> ElementFieldsList;
        private List<string> TaskFullNames;

        /// <summary>
        /// Экземпляр класса CreateRecordWindow - окно создания новой записи.
        /// </summary>
        public CreateRecordWindow(IRecordsController controller)
        {
            IsCreateWindow = true;
            Controller = controller;
            InitializeComponent();
            Settings();
        }

        /// <summary>
        /// Экземпляр класса CreateRecordWindow - окно изменения выбранных записей.
        /// </summary>
        public CreateRecordWindow(IRecordsController controller, IList<IUiRecord> selectedItems)
        {
            IsCreateWindow = false;
            SelectedItems = selectedItems.Cast<IUiRecord>().ToList();
            Controller = controller;
            InitializeComponent();
            Settings();
            SettingComponents();
        }
        
        #region Настройки окна

        /// <summary>
        /// Основные настройки.
        /// </summary>
        private void Settings()
        {
            TaskFullNames = new List<string>();
            CurrentRecord = new UiRecord();
            EnableComponents(false);
            if (IsCreateWindow)
            {
                Title = "Новая запись";
                BtnCreateRecord.Content = "Добавить";
                TxtBoxSection.Text = "Секция 1";
            }
            else
            {
                Title = "Редактирование";
                BtnCreateRecord.Content = "Изменить";
            }

            ComboBoxTaskType.ItemsSource = Controller.GetTaskTypes();
            ComboBoxTaskFrom.ItemsSource = Controller.GestTaskFrom();
            ComboBoxTaskFrom.Text = CurrentRecord.Discipline;
            ComboBoxTaskTo.ItemsSource = Controller.GetTaskTo();
            ComboBoxTaskTo.Text = CurrentRecord.Chapter;
            ComboBoxBuildingPart.ItemsSource = Controller.GetBuildingPart();
            ComboBoxBuildingPart.Text = CurrentRecord.BuildingPart;
            ComboBoxWorkName.ItemsSource = TaskFullNames;
            ComboBoxUnits.ItemsSource = Controller.GetUnits();
            ComboBoxUnits.Text = CurrentRecord.Units;

            TxtBoxSection.Text = CurrentRecord.Section;
            TxtBoxCount.Text = CurrentRecord.Count.ToString();
        }

        /// <summary>
        /// Настройки компонентов окна, на основе выбранных записей.
        /// </summary>
        private void SettingComponents()
        {
            SetComponentValue(ComboBoxTaskType, "WorkNameShort");
            SetComponentValue(ComboBoxTaskFrom, "Discipline");
            SetComponentValue(ComboBoxTaskTo, "Chapter");
            SetComponentValue(ComboBoxBuildingPart, "BuildingPart");
            CreateListTaskNames();
            SetComponentValue(ComboBoxWorkName, "WorkNameFull");
            SetComponentValue(TxtBoxSection, "Section");
            SetComponentValue(ComboBoxUnits, "Units");
            SetComponentValue(TxtBoxCount, "Count");
            EnableComponents(true);
            IsValid();
        }

        /// <summary>
        /// Задает значение свойства компонента.
        /// </summary>
        /// <param name="component">Компонент.</param>
        /// <param name="propertyName">Наименование свойства.</param>
        private void SetComponentValue(TextBox component, string propertyName)
        {
            Stack<string> stack = new Stack<string>();
            string prop;

            foreach (var item in SelectedItems)
            {
                prop = GetPropValue(item, propertyName);
                if (!stack.Contains(prop))
                    stack.Push(prop);
            }

            // Изменение свойств компонента.
            component.Text = stack.Count == 1 ? stack.Peek() : "";
        }

        /// <summary>
        /// Задает значение свойства компонента.
        /// </summary>
        /// <param name="component">Компонент.</param>
        /// <param name="propertyName">Наименование свойства.</param>
        private void SetComponentValue(ComboBox component, string propertyName)
        {
            Stack<string> stack = new Stack<string>();
            string prop;
            foreach (var item in SelectedItems)
            {
                prop = GetPropValue(item, propertyName);
                if (!stack.Contains(prop))
                    stack.Push(prop);
            }

            // Изменение свойств компонента.
            if (stack.Count > 1)
            {
                component.SelectedValue = null;
            }
            else
            {
                foreach (var e in component.ItemsSource)
                {
                    if (e.ToString() == stack.Peek())
                    {
                        component.IsEditable = true;
                        component.SelectedValue = e;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Получение значения свойства объекта по названию.
        /// </summary>
        /// <param name="obj">Объект.</param>
        /// <param name="propName">Наименование свойства.</param>
        /// <returns>Текстовое значение свойства.</returns>
        private string GetPropValue(object obj, string propName)
        {
            var result = obj.GetType()
                .GetProperty(propName)
                .GetValue(obj, null);
            return result == null ? "" : result.ToString();
        }

        #endregion

        #region ComponentIvents

        #region Click

        private void BtnCreateRecord_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(TxtBoxCount.Text.Replace(',', '.'),
                NumberStyles.Any,
                CultureInfo.InvariantCulture,
                out decimal count))
            {
                if (count > 0)
                { 
                    CurrentRecord.Count = count;
                }
                else
                {
                    MessageBox.Show("Значение количества должо быть больше 0."); return;
                }
            }
            else
            {
                MessageBox.Show("Некорректное значение количества."); return;
            }

            if (IsCreateWindow)
            {
                if (CurrentRecord.WorkNameFull != "" &
                    CurrentRecord.WorkNameFull != null)
                {
                    CurrentRecord.Discription = "";
                    CurrentRecord.ExportBy = Domain.Enums.ExportTypes.ByUser;
                    Controller.Create(CurrentRecord);
                }
            }
            else
            { 
                Controller.Edit(CurrentRecord, SelectedItems.Cast<IUiRecord>().ToList());
            }

            this.Close();
        }

        #endregion

        #region SelectionChanged

        private void ComboBoxTaskType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EnableComponents(ComboBoxTaskType.SelectedValue != null);
            CurrentRecord.WorkNameShort = GetChanges(e);
            CreateListTaskNames();
            IsValid();
        }

        private void ComboBoxTaskFrom_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentRecord.Discipline = GetChanges(e);
            CreateListTaskNames();
            IsValid();
        }
        private void ComboBoxTaskTo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentRecord.Chapter = GetChanges(e);
            CreateListTaskNames();
            IsValid();
        }
        private void ComboBoxBuildingPart_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentRecord.BuildingPart = GetChanges(e);
            CreateListTaskNames();
            IsValid();
        }
        private void ComboBoxWorkName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentRecord.WorkNameFull = GetChanges(e);
            SetStandardTypeAndAssignment();
            IsValid();
        }
        private void ComboBoxUnits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CurrentRecord.Units = GetChanges(e);
            IsValid();
        }
        #endregion

        #region TextChanged

        private void TxtBoxSection_TextChanged(object sender, TextChangedEventArgs e)
        {
            CurrentRecord.Section = TxtBoxSection.Text;
            IsValid();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = e.Text == "." ||  e.Text == "," ?
                TxtBoxCount.Text.Contains('.') ||  TxtBoxCount.Text.Contains(',') : // true, если бокс содержит '.' или ','
                !char.IsDigit(e.Text.ToCharArray()[0]);                             // false, если входное значение не является цифрой
        }


        private void TxtBoxCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (decimal.TryParse(TxtBoxCount.Text,
                                 NumberStyles.Any,
                                 CultureInfo.InvariantCulture,
                                 out decimal result))
            { 
                CurrentRecord.Count = result;
                
                IsValid();
            }
        }

        #endregion

        #endregion

        /// <summary>
        /// Получение данных из события SelectionChangedEventArgs.
        /// </summary>
        /// <returns>Текст.</returns>
        private string GetChanges(SelectionChangedEventArgs e) =>
            e.AddedItems.Cast<string>().ToArray().Length == 0 ? "" : e.AddedItems.Cast<string>().First();

        /// <summary>
        /// Создание списка с наименованиями работ.
        /// </summary>
        private void CreateListTaskNames()
        {
            if (ComboBoxTaskTo.SelectedValue == null ||
                ComboBoxTaskFrom.SelectedValue == null ||
                ComboBoxBuildingPart.SelectedValue == null)
            {
                ComboBoxWorkName.ItemsSource = new List<string>();
                ComboBoxWorkName.Text = string.Empty;
                ComboBoxWorkName.IsEnabled = 
                BtnCreateRecord.IsEnabled = false;
                return;
            }
            else
            {
                CurrentRecord.Chapter = ComboBoxTaskTo.SelectedValue.ToString();
                CurrentRecord.Discipline = ComboBoxTaskFrom.SelectedValue.ToString();
                CurrentRecord.BuildingPart = ComboBoxBuildingPart.SelectedValue.ToString();
            }

            TaskFullNames = new List<string>();

            // ["TaskName"]["DisciplineTo"]["DisciplineFrom"]["BuiltPart"]
            dynamic coll = new StructureBuilder().Repository;


            // Получение данных из TasksRepository.TasksDictionary
            if (TryGetValues(coll, CurrentRecord.WorkNameShort, out coll)) return;

            // Получение данных из вложенных словарей
            if (TryGetValues(coll, CurrentRecord.Chapter, out coll)) return;
            if (TryGetValues(coll, CurrentRecord.Discipline, out coll)) return;
            if (TryGetValues(coll, CurrentRecord.BuildingPart, out coll)) return;
            
            ElementFieldsList = coll;
            foreach (var item in ElementFieldsList)   
                TaskFullNames.Add(item.TaskName);

            ComboBoxWorkName.IsEnabled = true;
            ComboBoxWorkName.ItemsSource = TaskFullNames;
            ComboBoxWorkName.SelectedValue = CurrentRecord.WorkNameFull;
        }

        /// <summary>
        /// Попытка получения данных из IDictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="collection"></param>
        /// <param name="key"></param>
        /// <param name="coll"></param>
        /// <returns></returns>
        bool TryGetValues<TKey, TValue>(IDictionary<TKey, TValue> collection, TKey key, out dynamic coll)
        {
            if (!collection.ContainsKey(key))
            {
                ComboBoxWorkName.IsEnabled = false;
                ComboBoxWorkName.Text = string.Empty;
                coll = null;
                return true;
            }
            ComboBoxWorkName.IsEnabled = true;
            coll = collection[key];
            return false;
        }

        /// <summary>
        /// Присваивает значения свойствам StandardType и Assignment.
        /// </summary>
        private void SetStandardTypeAndAssignment()
        {
            foreach (var item in ElementFieldsList)
            {
                if (item.TaskName != CurrentRecord.WorkNameFull) continue;
                if (item.BuildingPart != CurrentRecord.BuildingPart) continue;

                CurrentRecord.StandardType = item.StandardType;
                CurrentRecord.Assignment = item.Assignment;
                break;
            }
        }

        /// <summary>
        /// Включение компонента BtnCreateRecord, если значения других компонентов валидны.
        /// </summary>
        private void IsValid()
        {
            if (CurrentRecord.Discipline != null &
                CurrentRecord.Chapter != null &
                CurrentRecord.BuildingPart != null &
                CurrentRecord.WorkNameFull != null &
                CurrentRecord.Section != null &
                CurrentRecord.Units != null &
                CurrentRecord.Count > 0)
            {
                if (CurrentRecord.Section == "Автостоянка" ||
                    CurrentRecord.Section.StartsWith("Секция") ||
                    CurrentRecord.Section.StartsWith("Секции"))
                {
                    BtnCreateRecord.IsEnabled = true;
                }
                else
                {
                    BtnCreateRecord.IsEnabled = false;
                }
            }
        }

        /// <summary>
        /// Управляет включением компонентов.
        /// </summary>
        /// <param name="b"></param>
        private void EnableComponents(bool b)
        {
            ComboBoxTaskFrom.IsEnabled = 
            ComboBoxTaskTo.IsEnabled = 
            ComboBoxBuildingPart.IsEnabled = 
            ComboBoxUnits.IsEnabled = 
            TxtBoxSection.IsEnabled = 
            TxtBoxCount.IsEnabled = b;
        }

    }
}

﻿using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using TheoryOfInformation.lab1.Encryptions;
using TheoryOfInformation.lab1.Encryptions.Models;
using static TheoryOfInformation.lab1.Encryptions.TextCleaner;

namespace TheoryOfInformation.lab1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool readFromFile;
        private bool encode;
        private IEnumerable<IEncryption> ecncryptions;
        private IEncryption encryption;

        public MainWindow()
        {
            ecncryptions = new List<IEncryption>() { new Casser() };
            InitializeComponent();
            encryptionsBox.ItemsSource = ecncryptions;
            inFileCheck.IsChecked = true;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (inFileCheck.IsChecked.Value)
            {
                fileUnit.Visibility = Visibility.Visible;
                textUnit.Visibility = Visibility.Hidden;
                readFromFile = true;
            }
            else
            {
                fileUnit.Visibility = Visibility.Hidden;
                textUnit.Visibility = Visibility.Visible;
                readFromFile = false;
            }
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e) => encode = encCheck.IsChecked.Value;

        private void encryptionsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;

            IEncryption selected = cmb.SelectedItem as IEncryption;
            if (selected.HasKey)
            {
                fileUnit.keyBox.Visibility = Visibility.Visible;
                textUnit.keyBox.Visibility = Visibility.Visible;
            }
            else
            {
                fileUnit.keyBox.Visibility = Visibility.Hidden;
                textUnit.keyBox.Visibility = Visibility.Hidden;
            }
            encryption = selected;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string text, key;
            if (readFromFile)
            {
                key = fileUnit.keyBox.Text;
                string path = fileUnit.InputFile.Text;
                text = File.ReadAllText(path);
            }
            else
            {
                text = textUnit.inputText.Text;
                key = textUnit.keyBox.Text;
            }

            string result = encode ? WorkWithText(null, null, encryption.Encrypte) : WorkWithText(null, null, encryption.Decrypte);

            if (readFromFile)
            {
                string path = fileUnit.OutputFile.Text;
                File.WriteAllText(path, result);
            }
            else
            {
                textUnit.outputText.Text = result;
            }
        }
    }
}

using System;
using System.Windows;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using DogeKit_Serializer.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DogeKit_Serializer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Device> deviceList;
        private Device selectedDevice;

        public MainWindow()
        {
            InitializeComponent();
            deviceList = new ObservableCollection<Device>();
            lvDevices.ItemsSource = deviceList;
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            DeviceList loadedDeviceList;
            XmlSerializer serializer = new XmlSerializer(typeof(DeviceList));

            StreamReader sr = new StreamReader(@"devices.xml");
            loadedDeviceList = (DeviceList)serializer.Deserialize(sr);
            sr.Close();
            sr.Dispose();

            //Set the local deviceList to one from deserialzed stream.
            deviceList.Clear();
            deviceList = loadedDeviceList.Devices;

            //Set itemsource again
            lvDevices.ItemsSource = deviceList;
        }

        private void btnAddDevice_Click(object sender, RoutedEventArgs e)
        {
            if (!deviceExists(TxtBxCodename.Text))
                deviceList.Add(new Device() { Name = txtBxDeviceName.Text, Codename = TxtBxCodename.Text });
            else
                MessageBox.Show("Device already exsits!");
        }

        private bool deviceExists(string codename)
        {
            foreach (Device d in deviceList)
            {
                if (d.Codename == codename)
                    return true;
            }
            return false;
        }

        private void btnRemoveDevice_Click(object sender, RoutedEventArgs e)
        {
            if (selectedDevice != null)
                deviceList.Remove((Device)lvDevices.SelectedItem);
            else
                MessageBox.Show("Select a device before removing.");
        }

        

        private void btnAddFactoryImage_Click(object sender, RoutedEventArgs e)
        {
            if (selectedDevice == null)
                MessageBox.Show("Please select a device above.");
            else
            if (!selectedDevice.fiExists(txtBxReleaseId.Text))
                selectedDevice.AddFactoryImage(txtBxBuild.Text, txtBxReleaseId.Text, txtBxVersion.Text);
            else
                MessageBox.Show("Factory image already exists for " + selectedDevice);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DeviceList dl = new DeviceList();
            foreach (Device d in deviceList)
            {
                dl.Devices.Add(d);
            }

            XmlSerializer ser = new XmlSerializer(typeof(DeviceList));
            using (FileStream fs = new FileStream(@"devices.xml", FileMode.Create))
            {
                ser.Serialize(fs, dl);
            }
        }

        private void lvDevices_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedDevice = (Device)lvDevices.SelectedItem;
            // Re-bind the ItemsSource for the factory image view
            if (selectedDevice != null)
            {
                lvFactoryImages.ItemsSource = selectedDevice.FactoryImages;
                lvTwrp.ItemsSource = selectedDevice.RecoveryVersions;
            }
            else
            {
                lvFactoryImages.ItemsSource = null;
                lvFactoryImages.Items.Clear();
                lvTwrp.ItemsSource = null;
                lvTwrp.Items.Clear();
            }
        }

        private void btnRemoveFactoryImage_Click(object sender, RoutedEventArgs e)
        {
            if (selectedDevice != null || lvFactoryImages.SelectedIndex == -1)
                selectedDevice.FactoryImages.Remove((FactoryImage)lvFactoryImages.SelectedItem);
            else
                MessageBox.Show("Select a factory image before removing.");
        }

        private void btnAddTWRP_Click(object sender, RoutedEventArgs e)
        {
            if (!selectedDevice.twrpExists(txtBxTwrpVersion.Text))
                selectedDevice.RecoveryVersions.Add(new TWRP() { Version = txtBxTwrpVersion.Text });
            else
                MessageBox.Show("TWRP with version " + txtBxTwrpVersion.Text + " already exists for " + selectedDevice);
        }
    }
}

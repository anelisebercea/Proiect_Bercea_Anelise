using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using DatabaseModel;
using System.Data;

namespace Proiect_Bercea_Anelise
{
  
    enum ActionState
    {
        New,
        Edit,
        Delete,
        Nothing
    }
    public partial class MainWindow : Window
    {
        ActionState action = ActionState.Nothing;

        DatabaseEntitiesModel ctx = new DatabaseEntitiesModel();
        CollectionViewSource aeroporturiVSource;
        CollectionViewSource bileteVSource;
        CollectionViewSource clientiVSource;
        CollectionViewSource reduceriVSource;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            aeroporturiVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("aeroporturiViewSource")));
            aeroporturiVSource.Source = ctx.Aeroporturi.Local;
            ctx.Aeroporturi.Load();

            bileteVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bileteViewSource")));
            bileteVSource.Source = ctx.Bilete.Local;
            ctx.Bilete.Load();

            clientiVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientiViewSource")));
            clientiVSource.Source = ctx.Clienti.Local;
            ctx.Clienti.Load();

            reduceriVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("reduceriViewSource")));
            reduceriVSource.Source = ctx.Reduceri.Local;
            ctx.Reduceri.Load();

            System.Windows.Data.CollectionViewSource aeroporturiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("aeroporturiViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // aeroporturiViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource bileteViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bileteViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // bileteViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource clientiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientiViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // clientiViewSource.Source = [generic data source]
            System.Windows.Data.CollectionViewSource reduceriViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("reduceriViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // reduceriViewSource.Source = [generic data source]

         

        }
        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Edit;
            //BindingOperations.ClearBinding(numeTextBox, TextBox.TextProperty);
            //SetValidationBinding();
        }
        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Delete;
        }


        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            aeroporturiVSource.View.MoveCurrentToNext();
        }
        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            aeroporturiVSource.View.MoveCurrentToPrevious();
        }

        private void btnNext1_Click(object sender, RoutedEventArgs e)
        {
            bileteVSource.View.MoveCurrentToNext();
        }
        private void btnPrev1_Click(object sender, RoutedEventArgs e)
        {
            bileteVSource.View.MoveCurrentToPrevious();
        }

        private void btnNext2_Click(object sender, RoutedEventArgs e)
        {
            bileteVSource.View.MoveCurrentToNext();
        }
        private void btnPrev2_Click(object sender, RoutedEventArgs e)
        {
            bileteVSource.View.MoveCurrentToPrevious();
        }

        private void btnNext3_Click(object sender, RoutedEventArgs e)
        {
            bileteVSource.View.MoveCurrentToNext();
        }
        private void btnPrev3_Click(object sender, RoutedEventArgs e)
        {
            bileteVSource.View.MoveCurrentToPrevious();
        }


        private void SaveAeroporturi()
        {
            Aeroporturi aeroport = null;
            if (action == ActionState.New)
            {
                try
                {

                    aeroport = new Aeroporturi()
                    {
                        Denumire = denumireTextBox.Text.Trim(),
                        Id = idTextBox.Text.Trim(),
                        Oras = orasTextBox.Text.Trim(),
                        Tara = taraTextBox.Text.Trim()
                    };
                   
                    ctx.Aeroporturi.Add(aeroport);
                    aeroporturiVSource.View.Refresh();
                    
                    ctx.SaveChanges();
                }
                
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    aeroport = (Aeroporturi)aeroporturiDataGrid.SelectedItem;
                    aeroport.Denumire = denumireTextBox.Text.Trim();
                    aeroport.Id = idTextBox.Text.Trim();
                    aeroport.Oras = orasTextBox.Text.Trim();
                    aeroport.Tara = taraTextBox.Text.Trim();
                
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    aeroport = (Aeroporturi)aeroporturiDataGrid.SelectedItem;
                    ctx.Aeroporturi.Remove(aeroport);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                aeroporturiVSource.View.Refresh();
            }
        }


        private void SaveBilete()
        {
            Bilete bilet = null;
            if (action == ActionState.New)
            {
                try
                {

                    bilet = new Bilete()
                    {

                        Data = DateTime.Parse(dataDatePicker.Text),
                        Durata = int.Parse(durataTextBox.Text),
                        Id = int.Parse(idTextBox1.Text),
                        ID_aeroport_aterizare = iD_aeroport_aterizareTextBox.Text.Trim(),
                        ID_aeroport_decolare = iD_aeroport_decolareTextBox.Text.Trim(),
                        Pret = double.Parse(pretTextBox.Text)
                    };
                    
                    ctx.Bilete.Add(bilet);
                    bileteVSource.View.Refresh();
                   
                    ctx.SaveChanges();
                }

                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    bilet = (Bilete)bileteDataGrid.SelectedItem;
                    bilet.Data = DateTime.Parse(dataDatePicker.Text);
                    bilet.Durata = int.Parse(durataTextBox.Text);
                    bilet.Id = int.Parse(idTextBox1.Text);
                    bilet.ID_aeroport_aterizare = iD_aeroport_aterizareTextBox.Text.Trim();
                    bilet.ID_aeroport_decolare = iD_aeroport_decolareTextBox.Text.Trim();
                    bilet.Pret = double.Parse(pretTextBox.Text);
                
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    bilet = (Bilete)bileteDataGrid.SelectedItem;
                    ctx.Bilete.Remove(bilet);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                bileteVSource.View.Refresh();
            }
        }

        private void SaveClienti()
        {
            Clienti client = null;
            if (action == ActionState.New)
            {
                try
                {

                    client = new Clienti()
                    {

                        Data_nasterii = DateTime.Parse(data_nasteriiDatePicker.Text),
                        Email = emailTextBox.Text.Trim(),
                        Id = int.Parse(idTextBox2.Text),
                        ID_reducere = iD_reducereTextBox.Text.Trim(),
                        Nume = numeTextBox.Text.Trim(),
                        Prenume = prenumeTextBox.Text.Trim()
                    };
                    
                    ctx.Clienti.Add(client);
                    clientiVSource.View.Refresh();
                    
                    ctx.SaveChanges();
                }

                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    client = (Clienti)clientiDataGrid.SelectedItem;
                client.Data_nasterii = DateTime.Parse(data_nasteriiDatePicker.Text);
                client.Email = emailTextBox.Text.Trim();
                client.Id = int.Parse(idTextBox2.Text);
                client.ID_reducere = iD_reducereTextBox.Text.Trim();
                client.Nume = numeTextBox.Text.Trim();
                client.Prenume = prenumeTextBox.Text.Trim();
                    
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    client = (Clienti)clientiDataGrid.SelectedItem;
                    ctx.Clienti.Remove(client);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                clientiVSource.View.Refresh();
            }
        }


        private void SaveReduceri()
        {
            Reduceri reducere = null;
            if (action == ActionState.New)
            {
                try
                {

                    reducere = new Reduceri()
                    {

                        Id = idTextBox3.Text.Trim(),
                        ID_bilet = int.Parse(iD_biletTextBox.Text),
                        ID_client = int.Parse(iD_clientTextBox.Text),
                        Procent_reducere = int.Parse(procent_reducereTextBox.Text)
                    };
                   
                    ctx.Reduceri.Add(reducere);
                    reduceriVSource.View.Refresh();
                    
                    ctx.SaveChanges();
                }

                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    reducere = (Reduceri)reduceriDataGrid.SelectedItem;
                    reducere.Id = idTextBox3.Text.Trim();
                    reducere.ID_bilet = int.Parse(iD_biletTextBox.Text);
                    reducere.ID_client = int.Parse(iD_clientTextBox.Text);
                    reducere.Procent_reducere = int.Parse(procent_reducereTextBox.Text);
                    
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    reducere = (Reduceri)reduceriDataGrid.SelectedItem;
                    ctx.Reduceri.Remove(reducere);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                reduceriVSource.View.Refresh();
            }
        }



        private void gbOperations_Click(object sender, RoutedEventArgs e)
        {
            Button SelectedButton = (Button)e.OriginalSource;
            Panel panel = (Panel)SelectedButton.Parent;

            foreach (Button B in panel.Children.OfType<Button>())
            {
                if (B != SelectedButton)
                    B.IsEnabled = false;
            }
            gbActions.IsEnabled = true;
        }

        private void ReInitialize()
        {

            Panel panel = gbOperations.Content as Panel;
            foreach (Button B in panel.Children.OfType<Button>())
            {
                B.IsEnabled = true;
            }
            gbActions.IsEnabled = false;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ReInitialize();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            TabItem ti = tbCtrlDatabase.SelectedItem as TabItem;
           //SetValidationBinding();
            switch (ti.Header)
            {
                case "Aeroporturi":
                    SaveAeroporturi();
                    break; 
                 case "Bilete":
                    SaveBilete();
                    break;
                case "Clienti":
                    SaveClienti();
                    break;
                case "Reduceri":
                    SaveBilete();
                    break;
            }
            ReInitialize();
        }


        /*
        private void SetValidationBinding()
        {
            Binding numeValidationBinding = new Binding();
            numeValidationBinding.Source = clientiViewSource;
            numeValidationBinding.Path = new PropertyPath("Nume");
            numeValidationBinding.NotifyOnValidationError = true;
            numeValidationBinding.Mode = BindingMode.TwoWay;
            numeValidationBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged; //string required
            numeValidationBinding.ValidationRules.Add(new StringNotEmpty());
            numeValidationBinding.SetBinding(TextBox.TextProperty, numeValidationBinding);
       
            

            Binding emailValidationBinding = new Binding();
            emailValidationBinding.Source = clientiViewSource;
            emailValidationBinding.Path = new PropertyPath("Email");
            emailValidationBinding.NotifyOnValidationError = true;
            emailValidationBinding.Mode = BindingMode.TwoWay;
            emailValidationBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged; //string required
            emailValidationBinding.ValidationRules.Add(new EmailValidator());
            emailValidationBinding.SetBinding(TextBox.TextProperty, emailValidationBinding);
            
        }
            */

    }
}

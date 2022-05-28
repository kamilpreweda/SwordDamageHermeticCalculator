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
using SwordDamageHermeticPrototype;


namespace SwordDamageHermeticCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random = new Random();
        
        SwordDamageHermetic swordDamageHermetic;      

        public MainWindow()
        {
            InitializeComponent();
            swordDamageHermetic = new SwordDamageHermetic(Roll3d6());
            DisplayDamage();
        }

        public void RollDice()
        {
            swordDamageHermetic.Roll = Roll3d6();
            DisplayDamage();
        }

        public void DisplayDamage()
        {
            damage.Text = $"Rzut: {swordDamageHermetic.Roll}, \npunkty obrażeń: {swordDamageHermetic.Damage}";
        }

        private void flaming_Checked(object sender, RoutedEventArgs e)
        {
            swordDamageHermetic.Flaming = true;
            DisplayDamage();
        }

        private void flaming_Unchecked(object sender, RoutedEventArgs e)
        {
            swordDamageHermetic.Flaming =false;
            DisplayDamage();
        }

        private void magic_Checked(object sender, RoutedEventArgs e)
        {
            swordDamageHermetic.Magic = true;
            DisplayDamage();
        }

        private void magic_Unchecked(object sender, RoutedEventArgs e)
        {
            swordDamageHermetic.Magic = false;
            DisplayDamage();
        }

        private void rollButton_Click(object sender, RoutedEventArgs e)
        {
            RollDice();
        }

        private int Roll3d6()
        {
            return random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
        }
    }
}
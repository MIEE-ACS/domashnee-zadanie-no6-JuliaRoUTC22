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
using System.Text.RegularExpressions;


namespace Wpf_homework_6
{

    class MeanOfTransportation
    {
        public string model_name
        {
            get;
            set;
        }

        public double average_speed;
        public double average_fuel_consumption;

        public int number_of_passengers
        {
            get;
            set;
        }

        public double passed_way
        {
            get;
            set;
        }
        public double fuel
        {
            get;
        }
        public double time
        {
            get;
        }

    }


    class Bicycle : MeanOfTransportation
    {

        public double BikeFuel;
        public double BikeTime;

        public override string ToString()
        {
            return String.Format("{0}\n\tВид средства передвижения: Велосипед\n\tСредняя скорость: {1} км/ч\n\tСредний расход топлива: {2} л/100 км\n\tЧисло пассажиров: {3}\n\tДля заданного расстояния S = {4} км - потребление топлива: {5} л; время движения: {6} мин.",
                                 model_name, average_speed, average_fuel_consumption, number_of_passengers, passed_way, BikeFuel, BikeTime);
        }
        public override bool Equals(object obj)
        {
            Bicycle o = obj as Bicycle;
            if (o.BikeFuel == this.BikeFuel)
                return true;
            else
                return false;
        }
    }


    class Automobile : MeanOfTransportation
    {
        public double CarFuel;
        public double CarTime;

        public override string ToString()
        {
            return String.Format("{0}\n\tВид средства передвижения: Легковой автомобиль\n\tСредняя скорость: {1} км/ч\n\tСредний расход топлива: {2} л/100 км\n\tЧисло пассажиров: {3}\n\tДля заданного расстояния S = {4} км - потребление топлива: {5} л; время движения: {6} мин.",
                                 model_name, average_speed, average_fuel_consumption, number_of_passengers, passed_way, CarFuel, CarTime);
        }
        public override bool Equals(object obj)
        {
            Automobile o = obj as Automobile;
            if (o.CarFuel == this.CarFuel)
                return true;
            else
                return false;
        }
    }


    class Truck : MeanOfTransportation
    {
        public double TruckFuel;
        public double TruckTime;

        public override string ToString()
        {
            return String.Format("{0}\n\tВид средства передвижения: Легковой автомобиль\n\tСредняя скорость: {1} км/ч\n\tСредний расход топлива: {2} л/100 км\n\tЧисло пассажиров: {3}\n\tДля заданного расстояния S = {4} км - потребление топлива: {5} л; время движения: {6} мин.",
                                  model_name, average_speed, average_fuel_consumption, number_of_passengers, passed_way, TruckFuel, TruckTime);
        }
        public override bool Equals(object obj)
        {
            Truck o = obj as Truck;
            if (o.TruckFuel == this.TruckFuel)
                return true;
            else
                return false;
        }
    }


    public partial class MainWindow : Window
    {
        List<MeanOfTransportation> Listing = new List<MeanOfTransportation>
        {
            new Truck { model_name =  "Shacman SX3318DT366", average_speed = 72, average_fuel_consumption = 38, number_of_passengers = 2,
                passed_way = 20, TruckFuel = 7.6, TruckTime = 162 },
            new Bicycle { model_name =  "Merida Cyclo Cross 300", average_speed = 20, average_fuel_consumption = 0, number_of_passengers = 1,
                passed_way = 0.5, BikeFuel = 0, BikeTime = 1.5 },
            new Automobile { model_name =  "Mercedes-Benz SLS AMG", average_speed = 136, average_fuel_consumption = 13.2, number_of_passengers = 4,
                passed_way = 68, CarFuel = 8.98, CarTime = 30 },
            new Bicycle { model_name =  "Subrosa Salvador Park BMX 20", average_speed = 24, average_fuel_consumption = 0, number_of_passengers = 1,
                passed_way = 1.4, BikeFuel = 0, BikeTime = 35 },
            new Truck { model_name =  "КАМАЗ 5320", average_speed = 86, average_fuel_consumption = 34, number_of_passengers = 3,
                passed_way = 93, TruckFuel = 31.62, TruckTime = 64.88 },
            new Automobile { model_name =  "Chevrolet Impala 1967", average_speed = 94, average_fuel_consumption = 26, number_of_passengers = 2,
                passed_way = 442, CarFuel = 114.92, CarTime = 282.1 },
        };

        bool input_textbox = false;
        bool input_cmb = false;


        public MainWindow()
        {
            InitializeComponent();
            Ltb.Items.Clear();

            for (int i = 0; i < Listing.Count; i++)
            {
                Ltb.Items.Add($"{i + 1}. {Listing[i].ToString()}");
            }
        }


        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {
            grid_add.Visibility = Visibility.Visible;
            grid_listing.Visibility = Visibility.Hidden;
            tb_fuel.IsEnabled = false;
            tb_time.IsEnabled = false;
        }


        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            input_textbox = true;

            try
            {
                //  tb_speed.Text.Replace('.', ',');
                if ((tb_speed.Text.Length != 0) && (Double.Parse(tb_speed.Text.Replace('.', ',')) > 299792458))
                {
                    MessageBox.Show("Ввод некорректен - значение превышает скорость света. Введите действительную среднюю скорость данной модели транспорта.", 
                        "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    input_textbox = false;
                    tb_speed.Clear();
                }

            }

            catch (FormatException)
            {
                MessageBox.Show("Некорректный ввод. Ячейка должна содержать среднюю скорость - числовое неотрицательное значение. Пожалуйста, введите снова.", 
                    "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                input_textbox = false;
                tb_speed.Clear();
            }

            try
            {
                if ((tb_consumption.Text.Length != 0) && (Double.Parse(tb_consumption.Text.Replace('.', ',')) > 300))
                {
                    MessageBox.Show("Введите действительный средний расход топлива данной модели транспорта.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    input_textbox = false;
                    tb_consumption.Clear();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный ввод. Ячейка должна содержать средний расход топлива - числовое неотрицательное значение. Пожалуйста, введите снова.", 
                    "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                input_textbox = false;
                tb_consumption.Clear();
            }

            try
            {
                if ((tb_passengers.Text.Length != 0) && (Int32.Parse(tb_passengers.Text) < 0))
                {
                    MessageBox.Show("Некорректный ввод количества пассажиров. Введите целое неотрицательное число.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    input_textbox = false;
                    tb_passengers.Clear();
                }

                if ((tb_passengers.Text.Length != 0) && (Int32.Parse(tb_passengers.Text) > 100))
                {
                    MessageBox.Show("Некорректный ввод. Пожалуйста, введите действительное количество пассажиров.", 
                        "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    input_textbox = false;
                    tb_passengers.Clear();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный ввод. Ячейка должна содержать количество пассажиров - числовое неотрицательное значение. Пожалуйста, введите снова.", 
                    "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                input_textbox = false;
                tb_passengers.Clear();
            }

            try
            {
                if ((tb_way.Text.Length != 0) && (Double.Parse(tb_way.Text.Replace('.', ',')) > 5000000))
                {
                    MessageBox.Show("Ввод некорректен - значение превышает максимальный пробег любого транспорта. Введите расстояние покороче.",
                        "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    input_textbox = false;
                    tb_way.Clear();
                }

            }

            catch (FormatException)
            {
                MessageBox.Show("Некорректный ввод. Ячейка должна содержать путь - числовое неотрицательное значение. Пожалуйста, введите снова.",
                    "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                input_textbox = false;
                tb_way.Clear();
            }



            if (tb_name.Text.Length == 0 || tb_speed.Text.Length == 0 || tb_passengers.Text.Length == 0 || tb_way.Text.Length == 0)
                    input_textbox = false;
                else
                    input_textbox = true;

                if (input_cmb && input_textbox)
                    btn_save.IsEnabled = true;
                else
                    btn_save.IsEnabled = false;


                if (tb_speed.Text.Length != 0 && tb_consumption.Text.Length != 0 && tb_way.Text.Length != 0)
                    btn_calculate.IsEnabled = true;
                else
                    btn_calculate.IsEnabled = false;
            
        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {
            Listing.RemoveAt(Ltb.SelectedIndex);
            Ltb.Items.Clear();

            for (int i = 0; i < Listing.Count; i++)
            {
                Ltb.Items.Add($"{i + 1}. {Listing[i].ToString()}");
            }
        }

        private void Btn_calculate_Click(object sender, RoutedEventArgs e)
        {
            grid_add.Visibility = Visibility.Hidden;

            double t;
            double r;

            double v = Double.Parse(tb_speed.Text.Replace('.', ','));
            double s = Double.Parse(tb_way.Text.Replace('.', ','));

            if ((tb_speed.Text.Length != 0) && (Double.Parse(tb_speed.Text.Replace('.', ',')) == 0))
            {
                MessageBox.Show("Нулевой ввод средней скорости некорректен - она должна быть положительной для расчёта времеи передвижения. Пожалуйста, введите действительную среднюю скорость данной модели транспорта.", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                input_textbox = false;
                tb_speed.Clear();
            }
            else {
                t = (s / v) * 60;
                tb_time.Text = Convert.ToString(t);
            }

            double f = Double.Parse(tb_consumption.Text.Replace('.', ','));
            if ((tb_consumption.Text.Length != 0) && (Double.Parse(tb_consumption.Text.Replace('.', ',')) == 0))
            {
                MessageBox.Show("Средний расход топлива данной модели транспорта задан нулём.\nНевозможно посчитать расход топлива для заданного расстояния будет нулевым также.\nЕсли выбран автомобиль, пожалуйста, введите другое значение расхода топлива.\nЕсли выбран велосипед - нажмите ОК.",
                    "Предупреждение!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                r = (f / 100) * s;
            tb_fuel.Text = Convert.ToString(r);
            }
           grid_add.Visibility = Visibility.Visible;
        }


        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            int type = cmb_mean.SelectedIndex;

            if ((tb_passengers.Text.Length != 0) && (Int32.Parse(tb_passengers.Text) > 7))
            {
                MessageBox.Show("Штраф за превышение допустимого количества перевозимых пассажиров!\nСогласно постановлению Правительства РФ от 23.10.1993 N 1090(ред.от 26.03.2020) 'О Правилах дорожного движения', п.22'Перевозка людей'.\nПожалуйста, введите другое, допустимое число пассажиров, чтобы добавить данную модель транспорта в базу данных.",
                    "Штраф!", MessageBoxButton.OK, MessageBoxImage.Information);
                input_textbox = false;
                tb_passengers.Clear();
            }

            grid_add.Visibility = Visibility.Hidden;
            grid_listing.Visibility = Visibility.Visible;

            switch (type)
            {
                case 0:
                    {
                        Listing.Add(new Bicycle {
                            model_name = tb_name.Text,
                            average_speed = Double.Parse(tb_speed.Text.Replace('.', ',')),
                            average_fuel_consumption = Double.Parse(tb_consumption.Text.Replace('.', ',')),
                            number_of_passengers = Int32.Parse(tb_passengers.Text),
                            passed_way = Double.Parse(tb_way.Text.Replace('.', ',')),
                            BikeFuel = Double.Parse(tb_fuel.Text.Replace('.', ',')),
                            BikeTime = Double.Parse(tb_time.Text.Replace('.', ','))
                        });
                        break;
                    }
                case 1:
                    {
                        Listing.Add(new Automobile {
                            model_name = tb_name.Text,
                            average_speed = Double.Parse(tb_speed.Text.Replace('.', ',')),
                            average_fuel_consumption = Double.Parse(tb_consumption.Text.Replace('.', ',')),
                            number_of_passengers = Int32.Parse(tb_passengers.Text),
                            passed_way = Double.Parse(tb_way.Text.Replace('.', ',')),
                            CarFuel = Double.Parse(tb_fuel.Text.Replace('.', ',')),
                            CarTime = Double.Parse(tb_time.Text.Replace('.', ','))
                        });
                        break;
                    }
                case 2:
                    {
                        Listing.Add(new Truck {
                            model_name = tb_name.Text,
                            average_speed = Double.Parse(tb_speed.Text.Replace('.', ',')),
                            average_fuel_consumption = Double.Parse(tb_consumption.Text.Replace('.', ',')),
                            number_of_passengers = Int32.Parse(tb_passengers.Text),
                            passed_way = Double.Parse(tb_way.Text.Replace('.', ',')),
                            TruckFuel = Double.Parse(tb_fuel.Text.Replace('.', ',')),
                            TruckTime = Double.Parse(tb_time.Text.Replace('.', ','))
                        });
                        break;
                    }
            }

            Ltb.Items.Clear();

              for (int i = 0; i < Listing.Count; i++)
              {
                Ltb.Items.Add($"{i + 1}. {Listing[i].ToString()}");
              }

            tb_name.Clear();
            tb_speed.Clear();
            tb_consumption.Clear();
            tb_passengers.Clear();
            tb_way.Clear();
            tb_fuel.Clear();
            tb_time.Clear();
            tb_passengers.Clear();

        }

      

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            input_cmb = false;
            if(cmb_mean.SelectedIndex != -1)
                    input_cmb = true;

            if (input_cmb && input_textbox)
                btn_save.IsEnabled = true;
            else
                btn_save.IsEnabled = false;

             if ((tb_way.Text != String.Empty) && (tb_speed.Text != String.Empty))
             {
                Btn_delete.IsEnabled = true;
             }
        }

        private void Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Ltb.SelectedIndex == -1)
                Btn_delete.IsEnabled = false;
            else
                Btn_delete.IsEnabled = true;
        }
    }
  
}

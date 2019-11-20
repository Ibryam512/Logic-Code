using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Linq;
namespace Logic_Code
{

    public partial class MainForm : Form
	{
		int level = 1;
		int money = 50;
		int index = 0;
		int code;
		int a;
		int b;
		int ac; 
		int tries = 5;
		int time = 60;
		int wins;
		int loses;
		int games;
		int turn = 0;
		string[] questions = {"Константин поставил на пост 7 войничета на разстояние 4 см едно от друго. На колко см е равно разстоянието от първия до последния войник?", "Един охлюв се изкачва от кладенец висок 50 метра. За колко дни ще изкачи кладенеца, ако през деня изкачва 2 метра, а през нощта слиза с 1 метър?", "", "", ""};
		string[] firstGradeE = {"6 - 2, 6 + 2, 4 + 2, 3 - 1", "3 + 2, 6 + 5, 9 - 3", "8 + 7, 16 - 5", "11 + 6, 18 - 1", "15 - 4, 11 + 3", "12 + 9, 9 + 3", "27 - 6, 15 + 4", "7 + 4 + 9, 19 - 5", "6 + 4 + 7, 8 + 5", "9 + 8 + 5, 22 - 7", "7 + 1 + 8, 14 - 1", "9 + 6 + 2, 7 + 5", "8 + 6 + 4, 20 - 10", "15 - 2 - 3, 7 + 8", "22 - 7 - 1, 14 + 7", "(27 - 8) + 1, 12 + 9", "(13 - 3) + 1, 18 - 7 ", "6 + 7, 34 - 5 - 6", "8 + 7 + 2, 17 - 2", "18 - 3, 9 + 8 + 4", "3 + 8 + 7, 9 + 11 + 1", "16 + 3 + 5, 6 + 7 + 4", "16 - 7 + 4, 15 + 8 - 2", "19 - 7 + 3, 15 - 3 - 2", "7 + 9 + 0, 1 + 12 - 1", "Димитър има 8 видео игри, а брат му Стоян има 6 видео игри. Колко видео игри имат двамата?, Деница си купила 12 мандарини и 6 ябълки. Колко общо плодове си купила Деница?", "Васил имал 9 точки на теста по четене и 7 точки на теста по математика. Колко точки имал общо Васил?, Ваня има 8 приятелки в училище и 5 приятелки от блока. Колко общо приятелки има Ваня?", "Лили имала 19 рибки в 1 аквариум. Баща и преместил 8 рибки в друг аквариум. Колко рибки останали в аквариума на Лили?, Силвия имала 17 дъвчащи бонбона. Тя дала 3 на сестра си. С колко бонбона останала Силвия?", "Майка ми купи 15 ябълки. 3 от ябълките се оказаха изгнили. Колко са хубавите ябълки?, Дилян имал 14 жетона за електронни игри. Той изиграл 4 жетона. С колко житона останал Дилян?", "Майка ми имаше 18 лева. Тя ми даде 2 лева и 3 лева на сестра ми. С колко пари остана майка?, В рейс пътували 12 пътника. На следващата спирка се качили още 5 и слезли 2. Колко са станали пътниците в рейса?", "Баскетболна топка струва  10 лева, а футболната – с 5 лева повече. Колко струва футболната топка?,  На олимпиада  по математика   Петър  има  17 точки, а  Мими – с  6  точки  по–малко. Колко точки има Мими?", "В книжарница Иван си купува 4 тетрадки, а Мария с 3 повече. Колко тетрадки двамата са си купили общо?, Теодор има 19 ябълки. Дава три на брат си, две на майка си и една на баща му. С колко ябълки остава Теодор?", "Ивайло има 6 книги. Мая има с 8 книги повече от него. Колко книги има Мая и колко общо книги имат двамата?", "Мартин има 24 колички, а Митко има с 11 по-малко от него. Колко колички има Митко и колко имат двамата общо?", "Константин на теста по математика е решил 15 задачи. Петър пък е решил с 7 задачи повече от него. Колко задачи е решил Петър и колко са решили двамата общо?", "27 - 4 - 6, 13 + 9 + 2", "Яна има 5 кукли. Лора има с 13 кукли повече от Яна. Колко кукли има Лора и колко кукли имат двете общо?", "10 + 18 - 2, 13 + 14 + 1", "Иван има 21 колички. Алекс има с 9 колички по-малко от него. Колко колички има Иван и колко са общо техните колички?", "18 + 7 - 6, 34 - 2 + 3", "24 + 9 + 2, 36 - 2 - 8"};
		string[] secondGradeE = {"3 * 4, 5 * 2", "5 * 6, 4 * 4", "3 * 6, 7 * 3", "8 * 5, 4 * 6", "3 * 9, 6 * 6", "8 * 4, 2 * 9", "75 + 23, 38 + 9", "46 + 37, 45 + 19", "56 + 15, 41 + 21", "15 + 26, 43 + 12", "87 - 32, 65 - 19", "65 - 8, 54 - 7", "72 - 29, 81 - 15", "90 - 54, 74 - 28", "100 - 77, 96 - 34", "24 / 8, 36 / 6, 56 / 7, 12 / 3", "48 / 6, 81 / 9, 63 / 7, 54 / 9", "64 / 8, 27 / 9, 35 / 7, 42 / 6", "90/ 10, 12 / 4, 45 / 5, 28 / 4", "32 / 8, 14 / 7, 28 / 4, 15 / 3", "27 + 17, 8 * 4", "6 * 7, 34 + 26", "8 * 8, 35 + 16", "45 + 43, 5 * 9", "67 + 18, 9 * 4", "87 - 24, 36 / 4, 56 / 7", "81 / 9, 56 - 15, 72 / 9", "95 - 19, 18 / 3, 18 / 6", "35 / 7, 32 / 8, 81 - 34", "28 / 4, 49 / 7, 65 - 13", "86 - 17, 5 * 6", "86 - 53, 8 * 5", "91 - 37, 4 * 9", "10 * 8, 45 - 23", "91 - 43, 7 * 9", "Лора има 5 гривни. Поля пък има 7 пъти повече от нея. Колко гривни има Поля и колко имат двете общо?", "Ясен има 8 флашки. Румен има 6 пъти повече от него. Колко флашки има Румен и колко имат двамата общо?", "8 * 6, 7 * 9", "10 * 6, 4 * 3", "6 * 3, 7 * 3", "9 * 9, 8 * 8"};
		string[] thirdGradeE = {"800 - 600, 34 - 32", "120 + 230, 2 * 3", "470 - 130, 50 - 43", "620 - 410, 4 * 2", "354 + 235, 2 * 2", "746 - 521, 8 / 2", "(423 + 256) - 554, 6 / 2", "(964 - 513) - 251, 3 * 3", "356 - 214, 2 / 2", "511 + 312, 1 * 2", "683 - 571, 10 / 2", "829 - 315, 3 + 4", "459 - (324 + 123), 7 * 2", "274 + (459 - 447), 2 * 3", "759 - (325 + 113), 4 / 2", "(347 + 232) - (125 + 121), 6 / 2", "527 + 149 + 284, 4 * 2", "754 - (387 + 259), 3 + 4", "276 - 276 + 319, 2 + 3", "547 - (234 + 112), 4 / 2", "Ивайло имал 480 лв. Той купил маса за 138 лв. и стол за 160 лв. С колко лева е останал Ивайло?, 9 / 3", "Намерете обиколката на правоъгълник ако страните му са с размери 200см. и 40 см., 11 - 6", "В един супермаркет са продали 579 кг. портокали за два дни. Първия ден са продали 265 кг. Колко килограма са продали втория ден?, 10 / 5", "Чичо Иван имал 678 лв. Той изхарчил 132 лв. за ремонт на колата и 135 лв. покупки. Колко лв. са останали след покупките?, 8 / 2", "Ирина има книга с 359 страници. Тя е прочела 233. Колко страници остава да прочете?, 2 * 3", "Кое число е със 104 по-голямо от 385?, 15 / 5", "Кое число е с 435 по-малко от 769?, 8 / 4", "Едит таблет струва 458 лева. На Соня не и достигат 142 лева, за да си го купи. Колко лева има Соня?, 12 / 2", "В едно училище има 472 момчета и 517 момичета. Колко деца има в училището?, 16 / 2", "Намерете периметърът на триъгълник, ако страните му са с дължини: 133, 202 и 147., 4 / 1", "625 - (625 - 403), 21 / 3", "(135 + 165) + (145 + 155), 9 / 3", "213 + 321 + 462, 2 * 2", "(543 + 212) - 320, 6 / 3", "(543 - 542) + 348, 2 * 4", "625 - [625 - (247 + 156)], 4 / 2", "125 + 135 + 145 + 155 + 165 + 175, 3 * 3", "Във влака пътуват 653 пътника. На първата гара слезли 187 и се качили 135. Колко пътници продължили да пътуват във влака?, 16 / 4", "Сумата на четните числа от 243 до 248, 2 * 2", "Разликата между най-голямото четно трицифрено число и най-малкото нечетно трицифрено число., 15 / 3", "Каква е сумата на всички трицифрени числа, чиято сума на цифрите е 2?, 12 / 2"};
		string[] fourthGradeE = {"7282 + 1358", "3861 + 1672", "2143 + 1357", "4156 - 1423", "2733 + 3142", "4132 - 2431", "7698 - (3451 + 2967)", "1945 + (7698 - 6523)", "8972 - (7634 - 5764)", "1564 + (7844 - 1264)", "13 * 14, 2 * 3", "23 * 11, 10 / 2", "15 * 25, 3 + 4", "26 * 18, 9 / 3", "17 * 14, 12 / 2", "28 * 22, 4 / 2", "18 * 24, 2 * 3", "22 * 22, 9 / 3", "25 * 19, 2 * 4", "32 * 23, 2 * 2", "3871 - 12 * 15", "23 * 16 + 1453", "24 * 24 + 3454", "3561 - 19 * 21", "5871 + 13 * 22", "8167 - 26 * 18", "3156 + 12 * 15", "9732 - 23 * 12", "8745 - 23 * 25", "24 * 13 + 7863", "145 * 21", "132 * 17", "212 * 33", "421 * 11", "179 * 16", "284 * 19", "368 * 23", "177 * 39", "116 * 43", "123 * 23", "357 * 13"};
		int[] fganswers = {4862, 5116, 1511, 1717, 1114, 2112, 2119, 2014, 1713, 2215, 1613, 1712, 1810, 1015, 1421, 2021, 1111, 1323, 1715, 1521, 1821, 2417, 1321, 1510, 1612, 1418, 1613, 1114, 1210, 1315, 1511, 1113, 1420, 1337, 2237, 1724, 1823, 2628, 1233, 1935, 3526};
		int[] sganswers = {1210, 3016, 1821, 4024, 2736, 3218, 9847, 8364, 7162, 4155, 5546, 5747, 4366, 3646, 2362, 3684, 8996, 8357, 9397, 4275, 4432, 4260, 6451, 8845, 8536, 6398, 9418, 7663, 5447, 7752, 6930, 3340, 5436, 8022, 4863, 3540, 4856, 4863, 6012, 1821, 8164};
		int[] tganswers = {2002, 3506, 3407, 2108, 5894, 2254, 1253, 2009, 1421, 8232, 1125, 5147, 1214, 2866, 3212, 3333, 9608, 1087, 3195, 2012, 1823, 4805, 3142, 4114, 1266, 4893, 3342, 3166, 9898, 4824, 4037, 6003, 9964, 4352, 3498, 4032, 9009, 6014, 7384, 8975, 4116};
		int[] ffanswers = {8640, 2189, 3500, 2733, 5875, 1701, 6418, 1175, 1870, 6580, 1826, 2535, 3757, 4683, 2386, 6162, 4326, 4843, 4758, 7364, 3691, 1821, 4030, 3162, 6157, 7699, 3336, 9456, 8170, 8175, 3045, 2244, 6996, 4631, 2864, 5396, 8464, 6903, 4988, 2829, 4641};
		int[] lqanswers = {24, 49, 13, 87};
		List<string> question = new List<string>();
		List<int> answer = new List<int>();
		Random generator = new Random();
        RegistryKey key;



        public MainForm()
		{
			
			
			InitializeComponent();
			Files();
			
			
		}
		public void Files()
		{
            key = null;
            if(!Registry.CurrentUser.OpenSubKey("SOFTWARE", true).GetSubKeyNames().Contains("LogicCode"))
            {
                key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\LogicCode");
                key.SetValue("wins", wins);
                key.SetValue("loses", loses);
                key.Close();
            }
            key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\LogicCode", true);
            wins = int.Parse(key.GetValue("wins").ToString());
            loses = int.Parse(key.GetValue("loses").ToString());
            key.Close();
            games = wins + loses;
            label4.Text = "Победи - " + wins;
            label5.Text = "Загуби - " + loses;
			label2.Text = "Брой игри - " + games;
		}
		public void Next()
		{
			turn++;
			if(turn == 1 || turn == 3 || turn == 6 || turn == 10 || turn == 15 || turn == 20 || turn == 25 || turn == 30 || turn == 35)
			{
				circularProgressBar1.Value = 100;
				level++;
				MessageBox.Show("Поздравления, ти си ниво " + level + ". Печелиш 150 монети!");
				circularProgressBar1.Text = level.ToString();
				circularProgressBar1.Value = 0;
				money += 150;
                labelMoney.Text = "Монети - " + money;
			}
			else
			{
				money += 15;
                labelMoney.Text = "Монети - " + money;
            }
			if(turn > 1 && turn < 3)
			{
				circularProgressBar1.Value = 50;
			}
			else if(turn > 3 && turn < 6)
			{
				circularProgressBar1.Value += 33;
			}
			else if(turn > 6 && turn < 10)
			{
				circularProgressBar1.Value += 25;
			}
			else if(turn > 10 && turn < 35)
			{
				circularProgressBar1.Value += 20;
			}
			else if(turn > 35 && turn < 41)
			{
				circularProgressBar1.Value += 16;
			}
            else if(turn == 41)
            {
                MessageBox.Show("Поздравления! Вие успяхте да решите всички задачи!");
                EndGame(true);
            }
				
			
			question.Remove(question[index]);
			answer.Remove(answer[index]);
			index = generator.Next(0, question.Count);
			labelTheLogic.Text = question[index];
			code = answer[index];
			a = code / 100 % 100;
			b = code % 100;
			ac = code / 10 % 1000;
			time = 60;
            circularProgressBar2.Value = time;
            circularProgressBar2.Text = time.ToString();
			
		}
		public void EndGame(bool result)
		{
            timer1.Stop();
            question.Clear();
        	answer.Clear();
        	turn = 0;
            if (result)
            {
                wins++;
                key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\LogicCode", true);
                key.SetValue("wins", wins);
                key.Close();
            }
            else
            {
                loses++;
                key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\LogicCode", true);
                key.SetValue("loses", loses);
                key.Close();
            }

            games = wins + loses;
            label4.Text = "Победи - " + wins;
            label5.Text = "Загуби - " + loses;
            label2.Text = "Брой игри - " + games;
            pictureBoxChoose.BringToFront();
		    comboBox1.BringToFront();
		    circularProgressBar1.Value = 0;
            comboBoxGrade.BringToFront();
			buttonStart.BringToFront();
			button5.BringToFront();
            label6.BringToFront();

			
		}
		public void StartGame()
		{
			pictureBox2.BringToFront();
			textBox1.BringToFront();
			labelTheLogic.BringToFront();
			buttonReady.BringToFront();
			circularProgressBar1.BringToFront();
			button2.BringToFront();
            circularProgressBar2.BringToFront();
            button6.BringToFront();
            button7.BringToFront();
            button8.BringToFront();
            button9.BringToFront();
            button10.BringToFront();
            button11.BringToFront();
            button12.BringToFront();
            button13.BringToFront();
            button14.BringToFront();
            button15.BringToFront();
            button16.BringToFront();
            level = 1;
			circularProgressBar1.Text = level.ToString();
			money = 50;
			labelMoney.Text = "Монети - " + money;
			tries = 5;
	        time = 60;
	        circularProgressBar1.Value = 0;
	        index = 0;
	        labelFirst.Text = "Първите две цифри";
	        labelSecond.Text = "Последните две цифри";
	        labelThird.Text = "Първите три цифри";
	        buttonFirst.Enabled = true;
	        buttonSecond.Enabled = true;
	        buttonThird.Enabled = true;

		}
		void ButtonEasyClick(object sender, EventArgs e)
		{
			pictureBoxChoose.BringToFront();
			comboBox1.BringToFront();
			comboBoxGrade.BringToFront();
			buttonStart.BringToFront();
			button5.BringToFront();
            label6.BringToFront();
			
		}
		void ButtonReadyClick(object sender, EventArgs e)
		{
			if(textBox1.Text == code.ToString())
			{
				Next();
			}
			else
			{
				tries--;
				if(tries == 0)
				{
					MessageBox.Show("Край на играта! Нямате повече опити.");
					EndGame(false);
				}
				else
				{
					MessageBox.Show("Останали опити: " + tries);
				}
			}
			
			textBox1.Text = "";
		}
        void ButtonStartClick(object sender, EventArgs e)
        {
        	
        	if(comboBox1.SelectedIndex == 0)
        	{
        		textBox1.MaxLength = 4;
        		button2.Enabled = true;
         		if(comboBoxGrade.SelectedIndex == 0)
        			{
         				
        				StartGame();
        				int index = generator.Next(0, 41);
        			    for (int i = 0; i < 41; i++) 
        			    {
        			    	question.Add(firstGradeE[i]);
        			    	answer.Add(fganswers[i]);
        			    }
        			    labelTheLogic.Text = question[index];
        				timer1.Start();
        				code = answer[index];
        			    a = code / 100 % 100;
        			    b = code % 100;
        			    ac = code / 10 % 1000;
        				
        			}
        			else if(comboBoxGrade.SelectedIndex == 1)
        			{
        				
        				StartGame();
        				int index = generator.Next(0, 41);
        				for (int i = 0; i < 41; i++) 
        			    {
        			    	question.Add(secondGradeE[i]);
        			    	answer.Add(sganswers[i]);
        			    }
        				labelTheLogic.Text = question[index];
        				timer1.Start();
        				code = answer[index];
        			    a = code / 100 % 100;
        			    b = code % 100;
        			    ac = code / 10 % 1000;
        			}
        			else if(comboBoxGrade.SelectedIndex == 2)
        			{
        				
        				StartGame();
        				int index = generator.Next(0, 41);
        				for (int i = 0; i < 41; i++) 
        			    {
        			    	question.Add(thirdGradeE[i]);
        			    	answer.Add(tganswers[i]);
        			    }
        				labelTheLogic.Text = question[index];
        				timer1.Start();
        				code = answer[index];
        			    a = code / 100 % 100;
        			    b = code % 100;
        			    ac = code / 10 % 1000;
        			}
        			else if(comboBoxGrade.SelectedIndex == 3)
        			{
        				
        				StartGame();
        				int index = generator.Next(0, 41);
        				for (int i = 0; i < 41; i++) 
        			    {
        			    	question.Add(fourthGradeE[i]);
        			    	answer.Add(ffanswers[i]);
        			    }
        				labelTheLogic.Text = question[index];
        				timer1.Start();
        				code = answer[index];
        			    a = code / 100 % 100;
        			    b = code % 100;
        			    ac = code / 10 % 1000;
        			}
        			else
        			{
        				MessageBox.Show("Моля изберете клас.");
        			}
        	
        	}
        	else if(comboBox1.SelectedIndex == 1)
        	{

                buttonStart.Enabled = false;
        	}
        	else
        	{
        		MessageBox.Show("Моля изберете категория.");
        	}
        	
        }
        
		void ButtonFirstClick(object sender, EventArgs e)
		{
	        if(money >= 200)
			{
	        	buttonFirst.Enabled = false;
				money = money - 200;
				MessageBox.Show(a.ToString());
				labelMoney.Text = "Монети - " + money;
			}
			else
			{
				MessageBox.Show("Нямаш достатъчно монети.");
			}
		}
		void ButtonSecondClick(object sender, EventArgs e)
		{
			
	        if(money >= 200)
			{
	        	buttonSecond.Enabled = false;
				money = money - 200;
				MessageBox.Show(b.ToString());
				labelMoney.Text = "Монети - " + money;
			}
			else
			{
				MessageBox.Show("Нямаш достатъчно монети.");
			}
		}
		void ButtonThirdClick(object sender, EventArgs e)
		{
	        if(money >= 375)
			{
	         	buttonThird.Enabled = false;
				money = money - 375;
				MessageBox.Show(ac.ToString());
				labelMoney.Text = "Монети - " + money;
			}
			else
			{
				MessageBox.Show("Нямаш достатъчно монети.");
			}
		}
		void ButtonExitClick(object sender, EventArgs e)
		{
			pictureBox4.SendToBack();
			buttonFirst.SendToBack();
			buttonSecond.SendToBack();
			buttonThird.SendToBack();
			buttonExit.SendToBack();
			labelFirst.SendToBack();
			labelSecond.SendToBack();
			labelThird.SendToBack();
			labelMoney.SendToBack();
		
		}
		void Button2Click(object sender, EventArgs e)
		{
	        pictureBox4.BringToFront();
			buttonFirst.BringToFront();
		   buttonSecond.BringToFront();
			buttonThird.BringToFront();
			 buttonExit.BringToFront();
			 labelFirst.BringToFront();
			labelSecond.BringToFront();
			 labelThird.BringToFront();
			 labelMoney.BringToFront();
		}
		void ButtonHowtoplayClick(object sender, EventArgs e)
		{
			pictureBox3.BringToFront();
			label3.BringToFront();
			button1.BringToFront();
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			pictureBox1.BringToFront();
			label1.BringToFront();
			buttonEasy.BringToFront();
			buttonHowtoplay.BringToFront();
			button3.BringToFront();
		}
		void Timer1Tick(object sender, EventArgs e)
		{
			
			time--;
			circularProgressBar2.Text = time.ToString();
			circularProgressBar2.Value = time;
			if(time < 10)
			{
				circularProgressBar2.Text = "0" + time;
			}
			if(time == 0)
			{
				
				timer1.Stop();	
				MessageBox.Show("Времето ти свърши! Край на играта.", "Game Over");
				EndGame(false);
			}
			
		}
		void ComboBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			if(comboBox1.SelectedIndex == 1)
			{
				comboBoxGrade.Enabled = false;
                buttonStart.Enabled = false;
			}
            else
			{
				comboBoxGrade.Enabled = true;
                buttonStart.Enabled = true;
			}
			
		}
		void textupdate(object sender, EventArgs e)
		{
			if(comboBox1.SelectedIndex == 0)
			{
				comboBox1.Text = "Математически";
			}
			else if(comboBox1.SelectedIndex == 1)
			{
				comboBox1.Text = "Логически";
			}
			else
			{
				comboBox1.Text = "Тип задачи";
			}
			
			if(comboBoxGrade.SelectedIndex == 0)
			{
				comboBoxGrade.Text = "Първи";
			}
			else if(comboBoxGrade.SelectedIndex == 1)
			{
				comboBoxGrade.Text = "Втори";
			}
			else if(comboBoxGrade.SelectedIndex == 2)
			{
				comboBoxGrade.Text = "Трети";
			}
			else if(comboBoxGrade.SelectedIndex == 3)
			{
				comboBoxGrade.Text = "Четвърти";
			}
			else
			{
				comboBoxGrade.Text = "Клас";
			}
			
			
		}
		void Over(object sender, MouseEventArgs e)
		{
			pictureBox6.BringToFront();
		}
		void Leave(object sender, EventArgs e)
		{
			pictureBox6.SendToBack();
		}
		void Button4Click(object sender, EventArgs e)
		{
			label2.SendToBack();
			label4.SendToBack();
			label5.SendToBack();
			button4.SendToBack();
			pictureBox7.SendToBack();
		}
		void Button3Click(object sender, EventArgs e)
		{
			pictureBox7.BringToFront();
			label2.BringToFront();
			label4.BringToFront();
			label5.BringToFront();
			button4.BringToFront();
			
	
		}
		public void Win()
		{
			wins++;
			using(StreamWriter win = new StreamWriter("wins.txt"))
			{
		      	win.WriteLine(wins);
			}
			using(StreamReader win = new StreamReader("wins.txt"))
			{
				wins = int.Parse(win.ReadLine());
				label4.Text = "Победи - " + wins;
				games++;
				label2.Text = "Брой игри - " + games;
			}
		}
		void ButtonCMBClick(object sender, EventArgs e)
		{
	      pictureBoxMB.SendToBack();
			labelTitle.SendToBack();
		   	labelInfo.SendToBack();
			buttonOK.SendToBack();
			buttonOK2.SendToBack();
			buttonCMB.SendToBack();
		}
		void PictureBox6Click(object sender, EventArgs e)
		{
	
		}
		void Button5Click(object sender, EventArgs e)
		{
            pictureBox1.BringToFront();
            label1.BringToFront();
            buttonEasy.BringToFront();
            buttonHowtoplay.BringToFront();
            button3.BringToFront();
        }
		void PictureBox2Click(object sender, EventArgs e)
		{
	
		}
		void Button6Click(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			textBox1.Text += button.Text;
		}
		void Button16Click(object sender, EventArgs e)
		{
			string text = textBox1.Text;
			string newtxt = "";
			for (int i = 0; i < text.Length - 1; i++) 
			{
				newtxt += text[i];
			}
			textBox1.Text = newtxt;
		}

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void PictureBoxChoose_Click(object sender, EventArgs e)
        {
            pictureBoxChoose.BringToFront();
            comboBox1.BringToFront();
            comboBoxGrade.BringToFront();
            buttonStart.BringToFront();
            button5.BringToFront();
            label6.BringToFront();
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox7.BringToFront();
            label2.BringToFront();
            label4.BringToFront();
            label5.BringToFront();
            button4.BringToFront();
        }
    }
		
	}


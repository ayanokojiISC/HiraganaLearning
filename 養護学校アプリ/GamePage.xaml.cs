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

namespace 養護学校アプリ
{
    /// <summary>
    /// GamePage.xaml の相互作用ロジック
    /// </summary>
    public partial class GamePage : Page
    {
        private int currentWordsCnt=0;
        private List<Button> questionList;


        public GamePage()
        {
            InitializeComponent();
            string QuestionText = "んんん";
            char[] questionArray = QuestionText.ToCharArray();
            string dummys = "あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもられるれろやゆよわをん";
            char[] dummysArray = dummys.ToCharArray();
            int ColumnNum=QuestionText.Length;
   
            char[] dummyChars=dummy_gen(dummysArray,questionArray);
            ColumnDefinition[] ColumnArray =new ColumnDefinition[ColumnNum];            
            QuestionFrame.ShowGridLines = true;
            for (int i=0; i < ColumnNum; i++)
            {
                ColumnArray[i] = new ColumnDefinition();
                Button btn = new Button();
                btn.FontSize = 400/ColumnNum;
                btn.Content = QuestionText[i];
                btn.Name = "btn" + i;
                QuestionFrame.ColumnDefinitions.Add(ColumnArray[i]);
                Grid.SetColumn(btn, i);
                QuestionFrame.Children.Add(btn);                
            }

            ((Button)QuestionFrame.Children[0]).Background = new SolidColorBrush(Colors.MediumSeaGreen);
            shuffle();
            

        }

        public void shuffle()
        {
            Random rnd = new Random();
            int buttoncnt = 7;
            int plusX = (int)((Canvas)dummyCanvas).Width / buttoncnt;
            int plusXresult = plusX;
            for (int i = 0; i < buttoncnt; i++)
            {

                int btnX = 0;
                btnX = rnd.Next(plusXresult - plusX, plusXresult - 100);
                Button btn = new Button();
                btn.Name = "dummybtn" + buttoncnt;

                int btnY = rnd.Next(((int)((Canvas)dummyCanvas).Height) - 100);
                btn.Content = "あ";
                dummyCanvas.Children.Add(btn);
                btn.Width = 100;
                btn.Height = 100;


                ((Button)dummyCanvas.Children[i]).Margin = new Thickness(btnX, btnY, 0, 0);
                plusXresult += plusX;

            }
        }

        private char[] dummy_gen(char[] dummysArray,char[] question)
        {
            char[] genStr;
            List<char> dummysList=new List<char>();

            foreach(char c in dummysArray){
                dummysList.Add(c);
            }
            foreach (char c in question)
            {
                dummysList.Remove(c);
            }

            


            return abcdefg;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dummyCanvas.Children.Clear();

            shuffle();
        }
    }
}

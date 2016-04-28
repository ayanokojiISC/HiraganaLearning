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
        private string QuestionText = "んんん";

        public GamePage()
        {
            InitializeComponent();
            
            
            int ColumnNum=QuestionText.Length;
   
            
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

            char[] dummyChars = dummy_gen();
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
                btn.Content = dummyChars[i];
                dummyCanvas.Children.Add(btn);
                btn.Width = 100;
                btn.Height = 100;


                ((Button)dummyCanvas.Children[i]).Margin = new Thickness(btnX, btnY, 0, 0);
                plusXresult += plusX;

            }
        }

        private char[] dummy_gen()
        {
            char[] questionArray = QuestionText.ToCharArray();
            string dummys = "あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもられるれろやゆよわをん";
            char[] dummysArray = dummys.ToCharArray();
           
            List<char> dummysList=new List<char>();
            List<char> gen_chars = new List<char>();
            
            foreach(char c in dummysArray){
                dummysList.Add(c);
            }
            foreach (char c in questionArray)
            {
                dummysList.Remove(c);
                gen_chars.Add(c);
            }
            Random rnd=new Random();
            char[] dummyExtract = new char[7-QuestionText.Length];
            for (int i=0; i < dummyExtract.Length; i++)
            {
                dummyExtract[i] = dummysList[rnd.Next(0,dummysList.Count-1)];
            }
            foreach (char c in dummyExtract)
            {
                gen_chars.Add(c);
            }
            char[] gen_Chars = gen_chars.ToArray();
            for (int i = 0; i < gen_Chars.Length; i++)
            {
                char temp = gen_Chars[i];
                int randomIndex = rnd.Next(0, gen_Chars.Length);
                gen_Chars[i] = gen_Chars[randomIndex];
                gen_Chars[randomIndex] = temp;
            }
            return gen_Chars;

            //コメント!!!
            //コメント追加!!
            //コメント追加2
            //abcdefg
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dummyCanvas.Children.Clear();

            shuffle();
        }


    }
}

﻿using System;
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
        private int currentWordsCnt=0;  //現在フォーカスが当たっている文字の番号
        private List<Button> questionList;  //問題のテキストを一文字ずついれるリスト
        private string QuestionText = "たけ"; //問題のテキスト。実際はファイルから読み込み

        public GamePage()
        {
            InitializeComponent();
            

            //
            //グリッドを問題テキストの文字数だけ均等に分割（カラム）・カラムに問題の文字を一文字ずつ割り当て
            //特にいじる必要もないので変数やfor文に関する説明は割愛します
            int ColumnNum=QuestionText.Length;                                      
            ColumnDefinition[] ColumnArray =new ColumnDefinition[ColumnNum];     
            for (int i=0; i < ColumnNum; i++)                                       
            {
                ColumnArray[i] = new ColumnDefinition();
                Button btn = new Button();
                btn.FontSize = 400/ColumnNum;
                btn.Content = QuestionText[i];
                btn.Style = this.FindResource("ButtonStyle1") as Style;
                btn.Name = "btn" + i;
                btn.HorizontalAlignment = HorizontalAlignment.Center;
                QuestionFrame.ColumnDefinitions.Add(ColumnArray[i]);
                Grid.SetColumn(btn, i);
                QuestionFrame.Children.Add(btn);                
            }

            ((Button)QuestionFrame.Children[0]).IsEnabled = false;  //関係ない
            
            
            
            shuffle(); 
            

        }

        //
        //画面下半分に現れる文字をシャッフル、ここでは座標のシャッフルもどきをしています。
        //特にいじる必要もないので変数やfor文に関する説明は割愛します
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
                btn.Style = this.FindResource("ButtonStyle1") as Style;
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

        //
        //画面下半分に現れる文字の生成、ループが多すぎるので何かいい案があれば教えて
        //
        private char[] dummy_gen()
        {
            char[] questionArray = QuestionText.ToCharArray();      //問題のテキストをchar型に変換
            string dummys = "あいうえおかきくけこさしすせそたちつてとなにぬねのはひふへほまみむめもられるれろやゆよわをん";  //ダミーになる文字達
            char[] dummysArray = dummys.ToCharArray();      //ダミー達、stringからchar配列に変身
           
            List<char> dummysList=new List<char>();     //addとかremoveを使いたいのでListにします
            List<char> gen_chars = new List<char>();    //


            
            foreach(char c in dummysArray){     //
                dummysList.Add(c);              //char型配列のダミー達を全部リストに収容
            }                                   //



            foreach (char c in questionArray)   //
            {                                   //
                dummysList.Remove(c);           //問題の文字達とダブったダミー達は削除
                gen_chars.Add(c);               //問題の文字達をリストに収容
            }                                   //



            Random rnd=new Random();    //randomオブジェクトの生成


            char[] dummyExtract = new char[7-QuestionText.Length];  //実際に表舞台に出るダミー達の配列


            for (int i=0; i < dummyExtract.Length; i++)                             //                         
            {                                                                       //
                dummyExtract[i] = dummysList[rnd.Next(0,dummysList.Count-1)];       //表舞台に出るダミー達をランダムに選抜
            }                                                                       //

            foreach (char c in dummyExtract)                                        //
            {                                                                       //
                gen_chars.Add(c);                                                   //問題の文字達が入ったリストにダミーをおまけで追加
            }                                                                       // 

            char[] gen_Chars = gen_chars.ToArray();                         //ダミーと問題の文字が入ったリストをchar型の配列に変換


            for (int i = 0; i < gen_Chars.Length; i++)                  //
            {                                                           //
                char temp = gen_Chars[i];                               //
                int randomIndex = rnd.Next(0, gen_Chars.Length);        //配列をシャッフルしてダミーと問題の文字を混ぜます
                gen_Chars[i] = gen_Chars[randomIndex];                  //
                gen_Chars[randomIndex] = temp;                          //
            }                                                           //


            return gen_Chars;           //ダミー達と問題の文字達をグチャグチャにした配列を返します

        }




        //シャッフルボタン、テスト時のみ使用//
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dummyCanvas.Children.Clear();

            shuffle();
        }


    }
}

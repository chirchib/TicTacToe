using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Game
    {
        private string[,] Field = new string[3, 3];
        public Player FirstPlayer;
        public Player SecondPlayer;
        public Player ComputerPlayer;

        public string Result { get; set; }

        public Game()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Field[i, j] = "*";
                }
            }
        }

        public void Start()
        {
            this.FirstPlayer = new Player("0");
            this.SecondPlayer = new Player("X");

            this.EndlessCycle();
        }

        private void EndlessCycle()
        {
            while (CheckOfResult())
            {
                this.FirstUpdate();
                this.SecondUpdate();
            }
            Console.WriteLine(Result);
        }

        public void FirstUpdate()
        {
            this.Draw();

            do
            {
                Console.WriteLine("First Player: Enter coordinates:\nOx from 0 to 2");
                FirstPlayer.Ox = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Oy from 0 to 2");
                FirstPlayer.Oy = Convert.ToInt32(Console.ReadLine());
            } while (Checking(FirstPlayer.Ox, FirstPlayer.Oy));

            Field[FirstPlayer.Ox, FirstPlayer.Oy] = FirstPlayer.Skin;
        }

        public void SecondUpdate()
        {
            this.Draw();

            if (!CheckOfResult())
            {
                return;
            }

            do
            {
                Console.WriteLine("Second Player: Enter coordinates:\nOx from 0 to 2");
                SecondPlayer.Ox = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Oy from 0 to 2");
                SecondPlayer.Oy = Convert.ToInt32(Console.ReadLine());
            } while (Checking(SecondPlayer.Ox, SecondPlayer.Oy));

            Field[SecondPlayer.Ox, SecondPlayer.Oy] = SecondPlayer.Skin;
        }

        public bool Checking(int x, int y)
        {
            if (0 <= x && x <= 2 && 0 <= y && y <= 2)
            {
                if (Field[x, y] == FirstPlayer.Skin || Field[x, y] == SecondPlayer.Skin)
                    return true;
                else return false;
            }
            else return true;
        }

        public void Draw()
        {

            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(Field[i,j], " ");
                }
                Console.WriteLine();
            }
        }

        public bool CheckOfResult()
        {
            if (CheckOfResultFirstPlayer() == false
            || CheckOfResultSecondPlayer() == false
            || CheckOfDraw() == false)
            {
                return false;
            }
            else return true;
        }

        public bool CheckOfResultFirstPlayer()
        {
            if ((Field[0,2] == Field[1,1] && Field[1,1] == Field[2,0] && Field[1,1] == FirstPlayer.Skin)
                || (Field[0, 0] == Field[1, 1] && Field[1, 1] == Field[2, 2] && Field[1, 1] == FirstPlayer.Skin))
            {
                Result = "FIRST PLAYER WON !!!";
                return false;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((Field[i, 0] == Field[i, 1] && Field[i,1] == Field[i, 2] && Field[i, 2] == FirstPlayer.Skin)
                        || (Field[0, j] == Field[1, j] && Field[1, j] == Field[2, j] && Field[2, j] == FirstPlayer.Skin))
                    { 
                        Result = "FIRST PLAYER WON !!!";
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckOfResultSecondPlayer()
        {
            if ((Field[0, 2] == Field[1, 1] && Field[1, 1] == Field[2, 0] && Field[1, 1] == SecondPlayer.Skin)
                || (Field[0, 0] == Field[1, 1] && Field[1, 1] == Field[2, 2] && Field[1, 1] == SecondPlayer.Skin))
            {
                Result = "SECOND PLAYER WON !!!";
                return false;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((Field[i, 0] == Field[i, 1] && Field[i, 1] == Field[i, 2] && Field[i, 2] == SecondPlayer.Skin)
                        || (Field[0, j] == Field[1, j] && Field[1, j] == Field[2, j] && Field[2, j] == SecondPlayer.Skin))
                    {
                        Result = "SECOND PLAYER WON !!!";
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckOfDraw()
        {
            if (CheckOfResultFirstPlayer() && CheckOfResultSecondPlayer())
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if ( Field[i,j] != FirstPlayer.Skin || Field[i, j] != SecondPlayer.Skin)
                        {
                            return true;
                        }
                    }
                }
                Result = "IT'S DRAW !!!";
                return false;
            }
        return true;
        }


    }
}

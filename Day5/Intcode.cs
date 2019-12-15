using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2019
{
    class Intcode
    {
        private int day; //used to reset easily

        //tracks the Intcode computers state
        private List<int> mem;
        private int PC;
        private bool running;
    
        public Intcode(int day)
        {
            this.day = day;
            mem = Helpers.readToIntList(day, ',',"i");
            PC = 0;
            running = false;
        }


        //runs until opcode 99 is encountered
        public void run()
        {
            running = true;
            while(running)
            {
                Step();
            }
        }

        //Returns the value at postion 0
        //Should probably throw an exception or something if the computer hasn't run
        public int getOutput()
        {
            return mem[0];
        }
    
        //Runs the computer for one instruction
        private void Step()
        {

            int istrWidth = 4;
            int istr = mem[PC];

            //decode instruction
            String strIstr = istr.ToString("00000");
            istr = Int32.Parse(strIstr.Substring(3));
            Console.WriteLine("Istr: " + strIstr);
            int op1;
            int op2;
            int op3;

            //execute stage
            if (istr == 1 || istr == 2 || istr == 7 || istr == 8)
            { 
                //decode for 4 byte wide instructions

                if (strIstr[2] == '1')
                    op1 = mem[PC + 1];
                else
                    op1 = mem[mem[PC + 1]];

                if (strIstr[1] == '1')
                    op2 = mem[PC + 2];
                else
                    op2 = mem[mem[PC + 2]];

                op3 = mem[PC + 3];

                if (istr == 1)
                    mem[op3] = op1 + op2;
                if (istr == 2)
                    mem[op3] = op1 * op2;
                if (istr == 7)
                {
                    if (op1 < op2)
                        mem[op3] = 1;
                    else
                        mem[op3] = 0;
                }
                if(istr == 8)
                {
                    if (op1 == op2)
                        mem[op3] = 1;
                    else
                        mem[op3] = 0;
                }


            }
            if(istr == 3)
            {
                
                Console.WriteLine("Input: ");
                int iIn = Int32.Parse(Console.ReadLine());
                mem[mem[PC + 1]] = iIn;
                istrWidth = 2;
            }
            if (istr == 4)
            {

                if (strIstr[2] == '1')
                    op1 = mem[PC + 1];
                else
                    op1 = mem[mem[PC + 1]];

                
                istrWidth = 2;
                Console.WriteLine("Output: " + op1);
            }

            if(istr == 5 || istr == 6)
            {
                istrWidth = 3;

                if (strIstr[2] == '1')
                    op1 = mem[PC + 1];
                else
                    op1 = mem[mem[PC + 1]];

                if (strIstr[1] == '1')
                    op2 = mem[PC + 2];
                else
                    op2 = mem[mem[PC + 2]];

                if(istr == 5)
                {
                    if (op1 != 0)
                    {
                        PC = op2;
                        return;
                    }
                    
                }
                else if(istr == 6)
                {
                    if (op1 == 0)
                    {
                        PC = op2;
                        return;
                    }
                }


            }
            if(istr == 99)
            {
                running = false;
            }


            PC += istrWidth;

        }

        //Resets the computer to its original memory state with a new noun and verb
        public void reset(int noun, int verb)
        {
            mem = Helpers.readToIntList(day, ',',"i");
            PC = 0;
            mem[1] = noun;
            mem[2] = verb;
            running = false;
        }




    }
}

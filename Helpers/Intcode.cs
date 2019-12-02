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
    
        public Intcode(int noun, int verb, int day)
        {
            this.day = day;
            mem = Helpers.readToIntList(day, ',',"i");
            PC = 0;
            mem[1] = noun;
            mem[2] = verb;
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
            int istr = mem[PC];
            int op1 = mem[mem[PC + 1]];
            int op2 = mem[mem[PC + 2]];
            int sto = mem[PC + 3];

            if (istr == 1)
                mem[sto] = op1 + op2;
            if (istr == 2)
                mem[sto] = op1 * op2;
            if(istr == 99)
            {
                running = false;
            }

            PC += 4;

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

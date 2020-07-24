using System;

namespace PatternStateInExample
{
    class Program
    {
        static void Main()
        {
            Father father = new Father(new Neutral());
            father.ReactOnSonMark(2);
            father.ReactOnSonMark(2);
            father.ReactOnSonMark(5);
            father.ReactOnSonMark(2);
            father.ReactOnSonMark(3);
            father.ReactOnSonMark(4);
            Console.ReadKey();
        }
    }

    class Father
    {
        public State State { get; set; }

        public Father(State state)
        {
            State = state;
        }
        public void ReactOnSonMark(int mark)
        {
            if (mark == 2)
                State.ChangeStateOnBad(this);
            else if (mark == 5)
                State.ChangeStateOnGood(this);
            else
                Console.WriteLine("Father didn't react");
        }
    }
    abstract class State
    {
        public abstract void ChangeStateOnBad(Father father);
        public abstract void ChangeStateOnGood(Father father);
    }
    class Neutral : State
    {
        public override void ChangeStateOnBad(Father father)
        {
            father.State = new Angree();
            Console.WriteLine("Changed on Angry from Neutral");
        }

        public override void ChangeStateOnGood(Father father)
        {
            father.State = new Happy();
            Console.WriteLine("Changed on Happy from Neutral");
        }
    }
    class Angree : State
    {
        public override void ChangeStateOnBad(Father father)
        {
            Console.WriteLine("Remained as Angry");
        }

        public override void ChangeStateOnGood(Father father)
        {
            father.State = new Neutral();
            Console.WriteLine("Changed on Neutral from Angree");
        }
    }
    class Happy : State
    {
        public override void ChangeStateOnBad(Father father)
        {
            father.State = new Neutral();
            Console.WriteLine("Changed on Neutral from Happy");
        }

        public override void ChangeStateOnGood(Father father)
        {
            Console.WriteLine("Remained as Happy");
        }
    }
}

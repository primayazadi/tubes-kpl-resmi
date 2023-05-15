using System;

namespace tubesbackuup
{
    public enum State
    {
        Start,
        LoggedIn,
        Configuration,
        AdditionalUserInfo,
        CategoryExpense,
        PaymentReminder,
        UpdatingInfo,
        TesAddIncome
    }

    public enum Input
    {
        Login,
        Register,
        AddIncome,
        AddExpense,
        ViewFinancialReport,
        Logout,
        ViewConfiguration,
        EnterAdditionalUserInfo,
        EnterCategoryExpense,
        PaymentReminder,
        UpdateInfo,
        TesAddIncome,
        Invalid
    }

    public class Automata
    {
        private readonly State[,] transitions;

        public Automata()
        {
            transitions = new State[8, 13]
            {
                { State.LoggedIn, State.Start, State.Start, State.Start, State.Start, State.Start, State.Configuration, State.AdditionalUserInfo, State.CategoryExpense, State.PaymentReminder, State.Start, State.Start, State.TesAddIncome },
                { State.LoggedIn, State.Start, State.Start, State.Start, State.LoggedIn, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start },
                { State.LoggedIn, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start },
                { State.LoggedIn, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start },
                { State.LoggedIn, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start },
                { State.LoggedIn, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start },
                { State.LoggedIn, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.PaymentReminder, State.Start, State.UpdatingInfo, State.Start },
                { State.LoggedIn, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start, State.Start }
            };
        }

        public State ProcessInput(State currentState, Input input)
        {
            int currentStateIndex = (int)currentState;
            int inputIndex = (int)input;
            State nextState = transitions[currentStateIndex, inputIndex];
            return nextState;
        }

        public Input GetInputFromChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    return Input.Login;
                case 2:
                    return Input.Register;
                case 3:
                    return Input.AddIncome;
                case 4:
                    return Input.AddExpense;
                case 5:
                    return Input.ViewFinancialReport;
                case 6:
                    return Input.Logout;
                case 7:
                    return Input.ViewConfiguration;
                case 8:
                    return Input.EnterAdditionalUserInfo;
                case 9:
                    return Input.EnterCategoryExpense;
                case 10:
                    return Input.PaymentReminder;
                case 11:
                    return Input.UpdateInfo;
                case 12:
                    return Input.TesAddIncome;
                default:
                    return Input.Invalid;
            }
        }
    }
}

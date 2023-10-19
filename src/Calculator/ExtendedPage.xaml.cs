using System.Data;

namespace Calculator;
//This is the extended page for the calculator which involves complex math operations.
public partial class ExtendedPage : ContentPage
{
    public ExtendedPage()
    {
        InitializeComponent();
    }
    string onride = "";
    string exp = "";
    int state = 1;


    string mathOp;
    double firstNo, secNo;


    //onselection of any operator on calculator screen using else if loops.
    void OnSelectNormal(object sender, EventArgs e)
    {

        Button button = (Button)sender;

        String clicked = button.Text;
        //when mod is pressesd
        if (clicked == "mod")
        {
            exp += "%";
        }
        //when x is clicked
        else if (clicked == "×")
        {
            exp += "*";
        }
        //when ÷ is clicked 
        else if (clicked == "÷")
        {
            exp += "/";
        }
        //when % is clicked 
        else if (clicked == "%")
        {
            exp += "*0.01";
        }
        else if (clicked == "^") 
        {
        exp += "^";
        }
        //when  is clicked 
        else
        {
            exp += clicked;
        }

        resultText.Text = exp;
    }
    //
    void OnSelectOperator(object sender, EventArgs e)
    {
        LockNumberValue(resultText.Text);

        state = -2;
        Button button = (Button)sender;
        string clicked = button.Text;
        if (clicked == "mod")
        {
            mathOp = "%";
        }
        else
        {
            mathOp = clicked;
        }
    }


    //when onclear C is selected this event triggers.
    void OnClear(object sender, EventArgs e)
    {
        exp = String.Empty;
        this.resultText.Text = "0";
        onride = string.Empty;
    }

    //when negative value is selected this event triggers.
    void OnNegative(object sender, EventArgs e)
    {
        var v = float.Parse(exp) * -1;
        this.resultText.Text = v.ToString();
        state = -1;
        exp = this.resultText.Text;
    }
    //when the newly added sqrt is selected this event triggers.
    void OnSelectSqrt(object sender, EventArgs e)
    {
        var sq = Math.Sqrt(int.Parse(exp));
        this.resultText.Text = sq.ToString();
        state = -1;
        exp = sq.ToString();
    }
    private void LockNumberValue(string text)
    {
        double number;
        if (double.TryParse(text, out number))
        {
            if (state == 1)
            {
                firstNo = number;
            }
            else
            {
                secNo = number;
            }

            onride = string.Empty;
        }
    }
    //when oncalculate is selected this event triggers.
    void OnCalculate(object sender, EventArgs ev)
    {
        DataTable dt = new DataTable();
        var v = dt.Compute(exp, "");
        this.resultText.Text = v.ToString();
        state = -1;
        exp = v.ToString();
    }
}

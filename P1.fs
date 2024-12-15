open System
open System.Windows.Forms

// Define the question type (either MultipleChoice or Written)
type QuestionType =
    | MultipleChoice of string list
    | Written

// Define a record for storing questions, answers, and correct answer
type Question = 
    { 
        QuestionText: string
        QuestionType: QuestionType
        CorrectAnswer: string 
    }

[<STAThread>]
do
    // Create the main form
    let form = new Form(Text = "Quiz Application")
    form.WindowState <- FormWindowState.Maximized // Set the form to full screen
    form.BackColor <- System.Drawing.Color.Wheat // Improve the background color

    // Label to display the question
    let questionLabel = new Label(Top = 100, Left = 100, Width = 800, Height = 50, Font = new System.Drawing.Font("Arial", 14.0F, System.Drawing.FontStyle.Bold))
    form.Controls.Add(questionLabel)

    // Radio buttons for answer options (for multiple-choice)
    let answerButtons = 
        [ for i in 0..3 -> 
            let btn = new RadioButton(Top = 200 + (i * 50), Left = 100, Width = 800, Font = new System.Drawing.Font("Arial", 12.0F))
            form.Controls.Add(btn)
            btn ]

    // TextBox for written answers (initially hidden)
    let answerTextBox = new TextBox(Top = 200, Left = 100, Width = 800, Font = new System.Drawing.Font("Arial", 12.0F), Visible = false)
    form.Controls.Add(answerTextBox)

    // Submit button to proceed to the next question or finish
    let submitButton = new Button(Text = "Submit", Top = 400, Left = 100, Width = 200, Height = 50, Font = new System.Drawing.Font("Arial", 12.0F))
    submitButton.BackColor <- System.Drawing.Color.LightSalmon
    submitButton.FlatStyle <- FlatStyle.Flat
    form.Controls.Add(submitButton)

    // Label to display the final score (hidden initially)
    let scoreLabel = new Label(Width = 800, Height = 50, Visible = false, Font = new System.Drawing.Font("Arial", 16.0F, System.Drawing.FontStyle.Bold), TextAlign = System.Drawing.ContentAlignment.MiddleCenter)
    form.Controls.Add(scoreLabel)

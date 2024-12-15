// Function to load a question from the questions list
    let loadQuestion index =
        let question = questions.[index]
        questionLabel.Text <- $"Q{index + 1}: {question.QuestionText}"

        // Show or hide answer options based on question type
        match question.QuestionType with
        | MultipleChoice answers ->
            // Show radio buttons for multiple-choice questions
            answerTextBox.Visible <- false
            for i in 0..3 do
                answerButtons.[i].Text <- answers.[i]
                answerButtons.[i].Checked <- false
                answerButtons.[i].Visible <- true
        | Written ->
            // Show TextBox for written questions and clear its content
            answerTextBox.Visible <- true
            answerTextBox.Text <- ""
            for i in 0..3 do
                answerButtons.[i].Visible <- false

    // Function to calculate the score (example implementation)
    let calculateScore (answers: string list) : int =
        answers
        |> List.mapi (fun i answer -> 
            let correctAnswer = questions.[i].CorrectAnswer
            if answer = correctAnswer then 1 else 0)
        |> List.sum
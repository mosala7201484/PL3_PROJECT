    // Event handler for the Submit button
    submitButton.Click.Add(fun _ ->
        // Find the selected answer
        let selectedAnswer =
            match questions.[currentQuestionIndex].QuestionType with
            | MultipleChoice _ ->
                answerButtons
                |> List.tryFindIndex (fun btn -> btn.Checked)
                |> Option.map (fun index -> answerButtons.[index].Text)
            | Written ->
                Some(answerTextBox.Text)

        match selectedAnswer with
        | Some answer ->
            // Add the selected answer to the user's answers
            userAnswers <- userAnswers @ [answer]

            // Check if there are more questions
            if currentQuestionIndex < questions.Length - 1 then
                currentQuestionIndex <- currentQuestionIndex + 1
                loadQuestion currentQuestionIndex
            else
                // Calculate the final score and display it
                let score = calculateScore userAnswers
                scoreLabel.Text <- $"You scored {score}/{questions.Length}!"
                centerScoreLabel()
                scoreLabel.Visible <- true
                submitButton.Enabled <- false // Disable the Submit button

                // Hide the last question
                questionLabel.Visible <- false
                answerTextBox.Visible <- false
                for btn in answerButtons do btn.Visible <- false
        | None ->
            MessageBox.Show("Please provide an answer before proceeding.", "Warning") |> ignore
    )

    // Load the first question
    loadQuestion currentQuestionIndex

    // Run the application
    Application.Run(form)
// Center the scoreLabel in the form
    let centerScoreLabel () =
        scoreLabel.Left <- (form.ClientSize.Width - scoreLabel.Width) / 2
        scoreLabel.Top <- (form.ClientSize.Height - scoreLabel.Height) / 2

    // State variables to track progress
    let mutable currentQuestionIndex = 0
    let mutable userAnswers: string list = []

    // Define the quiz questions
    let questions = 
        [ { QuestionText = "What is 2 + 2?"
            QuestionType = MultipleChoice ["3"; "4"; "5"; "6"]
            CorrectAnswer = "4" }
          { QuestionText = "What is your favorite color?"
            QuestionType = Written
            CorrectAnswer = "Blue" }
          { QuestionText = "What is the capital of France?"
            QuestionType = MultipleChoice ["London"; "Paris"; "Rome"; "Berlin"]
            CorrectAnswer = "Paris" }
          { QuestionText = "Who wrote 'Hamlet'?"
            QuestionType = Written
            CorrectAnswer = "Shakespeare" }
          { QuestionText = "Which planet is known as the Red Planet?"
            QuestionType = MultipleChoice ["Earth"; "Mars"; "Venus"; "Jupiter"]
            CorrectAnswer = "Mars" }
          { QuestionText = "What is the square root of 16?"
            QuestionType = Written
            CorrectAnswer = "4" }
          { QuestionText = "Which element has the chemical symbol O?"
            QuestionType = MultipleChoice ["Hydrogen"; "Oxygen"; "Gold"; "Silver"]
            CorrectAnswer = "Oxygen" }
          { QuestionText = "What is the boiling point of water in Celsius?"
            QuestionType = Written
            CorrectAnswer = "100" }
          { QuestionText = "Which continent is the largest by land area?"
            QuestionType = MultipleChoice ["Africa"; "Asia"; "Europe"; "Antarctica"]
            CorrectAnswer = "Asia" }
          { QuestionText = "What is the speed of light in km/s?"
            QuestionType = Written
            CorrectAnswer = "300,000" } ]
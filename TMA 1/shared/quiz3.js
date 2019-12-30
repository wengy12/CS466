var myQuestions = [];
var json_str = {};
var json_str1 = {};

function buildQuiz() {
	json_str = window.localStorage.getItem('questions3');
	myQuestions = JSON.parse(json_str);
// we'll need a place to store the HTML output
const output = [];

// for each question...
myQuestions.forEach((currentQuestion, questionNumber) => {
  // we'll want to store the list of answer choices
  const answers = [];

  // and for each available answer...
  for (letter in currentQuestion.answers) {
    // ...add an HTML radio button
    answers.push(
      `<label>
        <input type="radio" name="question${questionNumber}" value="${letter}">
        ${letter} :
        ${currentQuestion.answers[letter]}
      </label>`
    );
  }

  // add this question and its answers to the output
  output.push(
    `<div class="question"> ${currentQuestion.question} </div>
    <div class="answers"> ${answers.join("")}`
  );
});

// finally combine our output list into one string of HTML and put it on the page
quizContainer.innerHTML = output.join("");
}

function showResults() {
// gather answer containers from our quiz
const answerContainers = quizContainer.querySelectorAll(".answers");

// keep track of user's answers
let numCorrect = 0;

// for each question...
myQuestions.forEach((currentQuestion, questionNumber) => {
  // find selected answer
  const answerContainer = answerContainers[questionNumber];
  const selector = `input[name=question${questionNumber}]:checked`;
  const userAnswer = (answerContainer.querySelector(selector) || {}).value;

  // if answer is correct
  if (userAnswer === currentQuestion.correctAnswer) {
    // add to the number of correct answers
    numCorrect++;

    // color the answers green
    answerContainers[questionNumber].style.color = "lightgreen";
  } else {
    // if answer is wrong or blank
    // color the answers red
    answerContainers[questionNumber].style.color = "red";
  }
});

// show number of correct answers out of total
resultsContainer.innerHTML = `${numCorrect} out of ${myQuestions.length}`;
}

const quizContainer = document.getElementById("quiz");
const resultsContainer = document.getElementById("results");
const submitButton = document.getElementById("submit");

// display quiz right away
buildQuiz();

// on submit, show results
submitButton.addEventListener("click", showResults);

function othername() {
	myQuestions = [];
    var q = document.getElementById("question").value;
    var aa = document.getElementById("answer_a").value;
    var ab = document.getElementById("answer_b").value;
    var ac = document.getElementById("answer_c").value;
    var ca = document.getElementById("correct_answer").value;
    myQuestions.push({question: q, answers: {a: aa, b: ab, c: ac}, correctAnswer: ca});
	json_str1 = JSON.stringify(myQuestions);
	window.localStorage.setItem('questions3', json_str1);
    buildQuiz();
}

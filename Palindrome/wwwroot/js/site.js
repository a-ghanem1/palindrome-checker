// constants
const API_BASE_URL = "http://localhost:3333/api/palindrome";
const INPUT_ERROR_CLASS_NAME = "bg-danger";
const INPUT_CORRECT_CLASS_NAME = "bg-success";

// buttons
const jsButton = document.getElementById("jsButton");
const sqlButton = document.getElementById("sqlButton");
const dotnetButton = document.getElementById("dotnetButton");

// listeners
jsButton.addEventListener("click", () => {
    const jsInput = document.getElementById("jsPalindromeInput");
    const isPalindrome = jsIsPalindrome(jsInput.value);

    changeStylingAfterPalindromeCheck(isPalindrome, jsInput, jsButton);
});

sqlButton.addEventListener("click", async () => {
    const sqlInput = document.getElementById("sqlPalindromeInput");
    const isPalindrome = await sqlIsPalindrome(sqlInput.value);

    changeStylingAfterPalindromeCheck(isPalindrome, sqlInput, sqlButton);
});

dotnetButton.addEventListener("click", async () => {
    const dotnetInput = document.getElementById("dotnetPalindromeInput");
    const isPalindrome = await dotnetIsPalindrome(dotnetInput.value);

    changeStylingAfterPalindromeCheck(isPalindrome, dotnetInput, dotnetButton);
});

// functions
const jsIsPalindrome = (text) => {
    text = text.toLowerCase().replace(" ", "");

    // use two pointer method for better complexity O(n)
    let left = 0;
    let right = text.length - 1; // last index

    while (left < right) {
        if (text[left] !== text[right]) return false;

        left++;
        right--;
    }

    return true;
};

const sqlIsPalindrome = async (text) => {
    try {
        const response = await axios.get(API_BASE_URL + "/check/db/" + text);
        return response.data.isPalindrome;
    } catch (err) {
        return false
    }
};

const dotnetIsPalindrome = async (text) => {
    try {
        const response = await axios.get(API_BASE_URL + "/check/" + text);
        return response.data.isPalindrome;
    } catch (err) {
        return false
    }
};

const changeStylingAfterPalindromeCheck = (isPalindrome, element, button) => {
    if (isPalindrome) {
        element.classList.remove(INPUT_ERROR_CLASS_NAME);
        element.classList.add(INPUT_CORRECT_CLASS_NAME);
        button.classList.add('d-none')
    } else {
        element.classList.add(INPUT_ERROR_CLASS_NAME);
        element.classList.remove(INPUT_CORRECT_CLASS_NAME);
    }
};

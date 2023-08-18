const BASE_API_URL = "http://localhost:3013";

function displayUsers(users) {
    $(".users-container").empty();

    for (let i = 0; i < users.length; i++) {
        $(".users-container").append(makeUser(users[i]));
    }
}

function makeUser(user) {
    return `
        <div class="user">
            <h2>Student ID: ${user.ID}</h2>
            <p>FirstName: ${user.FirstName}</p>
            <p>LastName: ${user.LastName}</p>
            <p>Age: ${user.Age}</p>
            <p>Course: ${user.Course}</p>
        </div>
    `;
}

function displayError(error) {
    $(".users-container").html('<div class="error">Some Error has occurred!</div>');
}

function GetStudents() {
    $.ajax({
        method: "GET",
        url: `${BASE_API_URL}/GetStudents`,
        success: function (data) {
            displayUsers(data);
        },
        error: displayError,
    });
}
$("#search-input").on("input", function () {
    const searchTerm = $(this).val().trim();

    if (searchTerm.length === 0) {
        $("#suggestion-list").empty();
        return;
    }
    $.ajax({
        method: "GET",
        url: `${BASE_API_URL}/SearchStudents`,
        data: { searchTerm: searchTerm },
        success: function (data) {
            displaySuggestions(data);
        },
        error: function (error) {
            console.error(error);
        },
    });
});
function displaySuggestions(firstNames) {
    const suggestionList = $("#suggestion-list");
    suggestionList.empty();

    if (firstNames.length === 0) {
        const listItem = $("<li></li>").text("No record found");
        suggestionList.append(listItem);
    } else {
        firstNames.forEach(function (firstName) {
            const listItem = $("<li></li>").text(firstName);
            suggestionList.append(listItem);
        });
    }
}
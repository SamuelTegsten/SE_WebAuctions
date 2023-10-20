$(document).ready(function () {
    // Attach a submit event handler to the forms
    $("form").on("submit", function (event) {
        var form = $(this);
        var bidInput = form.find("input[type=number]");
        var currentBid = parseFloat(bidInput.attr("data-current-bid"));

        var bidValue = parseFloat(bidInput.val());

        if (bidValue <= currentBid) {
            // Bid is not higher than the current bid
            bidInput.addClass("error-input");
            // Display an error message
            form.find(".text-danger").text("Bid must be higher than the current bid.");
            event.preventDefault(); // Prevent form submission
        }
    });

    // Clear the error style and message when the input changes
    $("input[type=number]").on("input", function () {
        $(this).removeClass("error-input");
        $(this).closest("form").find(".text-danger").text("");
    });
});

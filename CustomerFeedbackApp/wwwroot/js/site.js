$(document).ready(function () {

    // Application version masking
    $("#appversion").mask('0Z.0Z.0Z.0Z', {
        placeholder: "__.__.__.__",
        translation: {
            'Z': {
                pattern: /[0-9]/,
                optional: true
            }
        }
    });

    // feedback form validation
    $("#feedbackform").validate({
        submitHandler: function (form) {

            $.ajax({
                method: "post",
                url: "Home/CreateFeedback",
                dataType: 'html',
                data: $("#feedbackform").serialize(),
                cache: false,
                processData: false
            }).done(function (response) {
                var responseData = JSON.parse(response);
                if (responseData.status) {
                    toastr["success"]("Feedback sent successfully and Jira Issue created. Issue Id " + responseData.issueKey, "gov2biz");
                } else {
                    toastr["error"]("Error occurred while saving the Feedback", "gov2biz");
                }
            }).fail(function () {
                toastr["error"]("Error occurred while sending Feedback","gov2biz");
            }).always(function () {
                $("#feedbackform").trigger("reset");
                setTimeout(function () {
                    $("#overlay").fadeOut(300);
                }, 500);
            });

            return false;
        },
        rules: {
            customername: {
                required: true,
                minlength: 4
            },
            emailaddress: {
                required: true,
                email: true
            },
            feedbacktype: "required",
            feedbackmessage: {
                required: true,
                minlength: 4
            },
            appversion: "required",
        },
        messages: {
            customername: {
                required: "Please enter your full name",
                minlength: "Your full name must consist of at least 4 characters"
            },
            emailaddress: "Please enter a valid email address",
            feedbacktype: "Select the feedback type",
            feedbackmessage: {
                required: "Please enter your feedback message",
                minlength: "Your feedback must consist of at least 4 characters",
            },
            appversion: "Please enter the application version"
        },
        errorElement: "span",
        errorPlacement: function (error, element) {
            // Add the `help-block` class to the error element
            error.addClass("help-block");

            if (element.prop("type") === "checkbox") {
                error.insertAfter(element.parent("label"));
            } else {
                error.insertAfter(element);
            }
        },
        highlight: function (element, errorClass, validClass) {
            $(element).parents(".col-sm-10").addClass("has-error").removeClass("has-success");
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).parents(".col-sm-10").addClass("has-success").removeClass("has-error");
        }
    });
});
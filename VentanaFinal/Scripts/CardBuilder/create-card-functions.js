$(document).ready(function() {

});

function addNewWordingTemplate() {
    var $newWording = $('#new-wording-template-textbox-container');
    $newWording.fadeIn();
    $newWording.find('input[type="text"]').focus();
}

function submitNewWordingTemplate(button) {
    var cardId = $('#card-id').val();
    var newWordingTemplate = $('#new-wording-template-textbox').val();
    var url = "/Card/AddWordingTemplatePartialViewResult";
    var data = {};
    data.newWordingTemplateName = newWordingTemplate;
    data.cardId = cardId;

    $.post(url, data, function(partialViewResult) {
        $('#wording-template-container').html(partialViewResult);
    });
}
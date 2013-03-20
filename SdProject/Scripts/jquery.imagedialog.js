// create our dialog  
$('#dialog-block').dialog({  
       autoOpen: false,  
        width: 400,  
        buttons: {  
              "Save": function () {  
                       closeDialog($(this))  
              }
        }  
});  

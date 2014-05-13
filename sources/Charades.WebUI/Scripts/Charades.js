function AddDictionary() {
    $('#addDict').css('cursor', 'pointer').mouseup(handleClick);
    //alert("Done");

    function handleClick(e) {
        $('#addDict').before('<input type="text" id="dictName"></input>').text("+add")
            .css('text-align', 'right').unbind("mouseup").mouseup(callController);
        $('#dictName').css('width', "8em").focus();
    }

    function callController(e) {
        var _name = $('#dictName').val();
        $.ajax({
            //type: "POST",
            url: '/Dictionaries/AddDictionary',
            data: { name: _name }
        })
        .done(function (data) {
            $('#dictionaries').html(data);
        });

    }
}

function AddDraggable() {
    //представить каждый элемент класса word как перетаскиваемый
    $(".word").draggable({
        cancel: 'span',                 //объектом в <span></> нельзя перетаскивать
        helper: "clone",                //делать копию перетаскиваемого объекта
        //начало перетаскивания
        start: function (e, ui) {
            //сделать родительский объект полупрозрачным
            $(this).css('opacity', '0.5');
        },
        //завершение перетаскивания
        stop: function (e, ui) {
            //восстановить непрозачность родительського элемента
            $(this).css('opacity', '');
        }
        //задать обработчики событий для мышки над объектом
    }).hover(handleMouseEnter, handleMouseLeave);
}

function AddDroppable() {
    //представить каждый элемент класса droppableDictionary как droppable
    $('.droppableDictionary').droppable({
        hoverClass: 'dictHover',        //css стиль, когда перетискиваемый элемент находится 
        //над данным объектом
        //когда перетаскиваемый объект находится над
        over: function (e, ui) {
            //сделать перетаскиваемый объект полупрозрачным
            ui.helper.css('opacity', '0.6');
        },
        //когда перетаскиваемый объект 'выходит' из даного 
        out: function (e, ui) {
            ui.helper.css('opacity', '');
        },
        //при сбрасывании
        drop: function (e, ui) {
            //извель ID слова и словаря
            var wordId = ui.draggable.context.id.split('_')[1];
            var dictId = $(this).attr('id').split('_')[1];
            //инициировать асинхронную отправку
            $.ajax({
                //вызвать метод действия
                url: '/Home/AddWord',
                //передать ID
                data: { wordId: wordId, dictId: dictId }
            });
        }
    });

}

function AddAutocomplete() {
    $('#autocomplete').autocomplete({
        source: '/Searching/GetWords',
        minLength: 0,
        //change: function(e, ui) {
        //    var array = new Array();
        //    for (var i = 0; i < ui.content.length; i++) {
        //        var word = new Object();
        //        word.WordId = ui.content[i].WordId;
        //        word.Name = ui.content[i].value;
        //        word.LevelId = 0;
        //        array[i] = word;
        //        delete word;
        //    }
        //    var string = JSON.stringify(array);
        //    //alert(string);
        //    $.ajax({
        //        data: { jsonWords: string },
        //        url: '/Home/RefreshWords'
        //    }).done(function (data) {
        //        $('#words').html(data);
        //        AddDraggable();
        //        AddDroppable();
        //    });
        //},
        //close: function(e, ui) {
            //alert("I'm closed");
        //},
        //create: function (e, ui) {
        //    alert("I'm created");
        //},
        //focus:function (e, ui) {
        //        alert("I'm focused");
        //},
        ////open: function(e, ui) {
        ////    alert("I'm opened");
        ////},
        response:
            function (e, ui) {
                var array = new Array();
                for (var i = 0; i < ui.content.length; i++) {
                    var word = new Object();
                    word.WordId = ui.content[i].WordId;
                    word.Name = ui.content[i].value;
                    word.LevelId = 0;
                    array[i] = word;
                    delete word;
                }
                //var pathname = $(location).attr('href');
                //var string = JSON.stringify(array);


                //var term = $('#autocomplete').val();
                ////alert(string);
                //$.ajax({
                //    data: { term: term },
                //    url: '/Home/Searchable'
                //}).done(function (data) {
                //    $('DIV.content-wrapper.main-content.clear-fix').html(data);
                //    AddDraggable();
                //    AddDroppable();
                //});



            }
        //search: function (e, ui) {
        //    alert("I'm searched");
        //},
        //select: function(e, ui) {
        //    alert("I'm selected");
        //}

    });

}


//------------------------------------------Обработчики событий--------------------------------------
//обработчик события мышки "над"
function handleMouseEnter(e) {
    //закрасить объект
    $(this).css({ 'background-color': ' #CCC' });
}
//обработчик "выхода" мышки
function handleMouseLeave(e) {
    //вернуть цвет объекта
    $(this).css('background-color', '');
}

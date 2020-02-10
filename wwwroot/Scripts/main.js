window.onload = function () {
    let word;
    let input_value = this.document.querySelector('input[name="value"]');
    let cur_id;
    let cur_lang;
    let cur_cnt;
    let cur_word;

    WordContol = (e) => {
        e.target.value = "";
        e.target.value = e.target.value.slice(0, -1);
        let words = document.querySelectorAll('.word');
        for (let i = 0; i < words.length; i++) {
            if (words[i].getAttribute('data-num') == e.key) {
                if (!words[i].classList.contains('active')) {
                    words[i].classList.add('active');
                    word = words[i].querySelector('p').innerHTML;
                    cur_id = words[i].getAttribute('data-id');
                    cur_lang = words[i].getAttribute('data-lang');
                    cur_cnt = words[i].getAttribute('data-cnt');
                    cur_word = words[i];
                }
                else {
                    words[i].classList.remove('active');
                    cur_id = undefined;
                }
            }
            else {
                words[i].classList.remove('active');
            }
        }
        input_value.value = word;
    }

    Submit = () => {
        input.disabled = true;
        $.get("Home/Check", { Id: cur_id, Lang: cur_lang, Value: input.value }, function (data) {
            if (data == "no_words") {
                cur_word.remove();
                input_value.value = "";
                input.value = "";
                let score = document.querySelector('input[name="count"]');
                score.value = parseInt(score.value) + parseInt(cur_cnt);
                document.getElementById("count").innerHTML = "Ваш счет : " + score.value;
                word = "";
            }
            else if (data=="not")
            {
                console.log("not");
            }
            else if (data != 'error') {
                let model = JSON.parse(data);
                cur_word.querySelector('p').innerHTML = model.Value;
                cur_word.setAttribute('data-id', model.Id);
                cur_word.setAttribute('data-lang', model.Lang);
                cur_word.setAttribute('data-cnt', model.Cnt);
                cur_word.querySelector('.cnt').innerHTML = model.Cnt;
                input.value = "";
                cur_word.classList.remove('active');
                cur_id = undefined;
                let score = document.querySelector('input[name="count"]');
                score.value = parseInt(score.value) + parseInt(cur_cnt);
                document.getElementById("count").innerHTML = "Ваш счет : " + score.value;
                input_value.value = "";
            }
            else {
                input.value = "";
            }
            input.disabled = false;
            input.focus();
        });
    }

    ChangeLang = (e) => {
        let rus_array = [
            'й', 'ц', 'у', 'к', 'е', 'н', 'г', 'ш', 'щ', 'з', 'х', 'ъ', 'ф', 'ы', 'в', 'а', 'п'
            , 'р', 'о', 'л', 'д', 'ж', 'э', 'я', 'ч', 'с', 'м', 'и', 'т', 'ь', 'б', 'ю'
        ];
        let en_array = [
            'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', '[', ']', 'a', 's', 'd', 'f', 'g'
            , 'h', 'j', 'k', 'l', ';', '\'', 'z', 'x', 'c', 'v', 'b', 'n', 'm', ',', '.'
        ];
        input.value = input.value.toLowerCase();
        let input_lang = "en";
        if (rus_array.indexOf(input.value[input.value.length - 1]) != -1)
            input_lang = "rus";
        if (cur_lang == input_lang) {
            if (input_lang == "en") {
                input.value = input.value.substring(0, input.value.length - 1) + rus_array[en_array.indexOf(input.value[input.value.length - 1])];
            }
            else {
                input.value = input.value.substring(0, input.value.length - 1) + en_array[rus_array.indexOf(input.value[input.value.length - 1])];
            }
        }
    }

    KeyUp = (e) => {      
        if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode >= 96 && e.keyCode <= 105)) {
            WordContol(e);
            return;
        }
        if (typeof (cur_id) === 'undefined') {
            e.target.value = e.target.value.slice(0, -1);
            return;
        }
        if (e.keyCode == 13) {
            Submit();
            return;
        }
        //if (e.keyCode != 8) {
        //    ChangeLang(e);
        //}
    }

    MovingDiv = () => {

    }

    let input = document.querySelector('input[name="translate"]');
    input.focus();
    input.addEventListener('keyup', KeyUp);

}
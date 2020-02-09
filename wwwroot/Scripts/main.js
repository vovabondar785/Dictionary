window.onload = function () {

    KeyUp = (e) => {
        if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode >= 96 && e.keyCode <= 105)) {
            e.target.value = e.target.value.slice(0, -1);
            let words = document.querySelectorAll('.word');
            for (let i = 0; i < words.length; i++) {  
                if (words[i].getAttribute('data-num') == e.key) {
                    words[i].className += " active";
                    break;
                }
            }
            return;
        }
    }

    let input = document.querySelector('input[name="translate"]');
    input.focus();
    input.addEventListener('keyup', KeyUp);

    
}
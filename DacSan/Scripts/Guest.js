$(function () {
    $('a#btn-search-modal').click(function () {

        $('#searchmodal').modal({
            backdrop: 'static',
            keyboard: false,
            show: true
        });

        $('#searchmodal').on('shown.bs.modal', function () {
            $('#search-product input[name="key"]').focus();
        });
        return false;
    });
})

$(function () {
    $('.btn-menu-mobile').click(function () {
        id = $(this).attr('data-menu');
        $(id).toggleClass('open');
    });
    $('.btn-close').click(function () {
        $(this).parent().toggleClass('open');
    });

    $('.arrow-sub-vmenu').click(function () {
        $(this).find('.fa').toggleClass('fa-angle-down');
    });
});


$(function () {
    var pname = ((document.title != '') ? document.title : ((document.querySelector('h1') != null) ? document.querySelector('h1').innerHTML : ''));
    var ga = document.createElement('script');
    ga.type = 'text/javascript';
    ga.async = 1;
    ga.src = '//live.vnpgroup.net/js/web_client_box.php?hash=717a500990eeecbea77b6db2dc3e05ae&data=eyJzc29faWQiOjEyMDc5MDMsImhhc2giOiJhNWU0ZmUzNmUxYTAyMjk5M2Q0Zjg0Mzg0ZmRlNzU3ZiJ9&pname=' + pname;
    var s = document.getElementsByTagName('script');
    s[0].parentNode.insertBefore(ga, s[0]);
})();

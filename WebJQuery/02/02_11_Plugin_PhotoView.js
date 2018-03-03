(function ($) {
    var settings;           //한개 이상의 매개변수를 담을 그릇 : params, 해시

    //photomatic라는 이름의 jQuery 플러그인 생성
    $.fn.photomatic = function (callerSettings)
    {
        //extend 함수에 의해 한 개 이상의 매개변수를 동적으로 받을 수 있다.
        settings = $.extend({
            photoElement: "#photoviewPhoto",            //넘겨온 썸네일 포토리스트
            transformer: function (name) { return name.replace(/images/, 'bigs'); },     //큰 이미지의 경로
            nextControl: null,          //다음 버튼, 지정하지 않으면 설정되지 않는다.
            previousControl: null,      //이전 버튼
            firstControl: null,         //처음 버튼
            lastControl: null,          //마지막 버튼
        }, callerSettings || {});       //공식과 같은 코드(?)

        settings.photoElement = $(settings.photoElement);
        settings.thumbnails = this.filter('img');               //img 요소만 settings에 thumbails 프로퍼티에 저장
        settings.thumbnails.each(function (n) { this.index = n; });
        settings.current = 0;                       //현재 보여지는 이미지의 인덱스 저장

        settings.thumbnails.click(function () { showPhoto(this.index); });  //썸네일 목목을 순회하여
        //나머지 연산자를 사용하여 리스트의 끝에 도달시 인덱스를 다시 처음으로 설정
        settings.photoElement.click(function () { showPhoto((settings.current + 1) % settings.thumbnails.length); });

        //버튼 등록
        //처음
        $(settings.firstControl).click(function () { showPhoto(0) });

        //이전
        $(settings.previousControl).click(function () {
            showPhoto((settings.thumbnails.length + settings.current - 1) %
                settings.thumbnails.length);
        });

        //다음
        $(settings.nextControl).click(function ()
        {
            showPhoto((settings.current + 1) % settings.thumbnails.length);
        });

        //마지막
        $(settings.lastControl).click(function () { settings.thumbnails.length - 1 });

        //처음 로드시 첫번째 이미지를 보여줌.
        showPhoto(0);

        return this;
    };


    //사진 보여주기 함수
    var showPhoto = function (index)
    {
        settings.photoElement
            .attr('src',                                //src 속성 대입
            settings.transformer(                       //transformer 함수를 사용하여 썸네일을 큰이미지로 변경
                settings.thumbnails[index].src));       //index에 해당하는 썸네일의 src특성을 찾는다.
        settings.current = index;                       //현재 인덱스를 다시 저장
    };

})(jQuery);
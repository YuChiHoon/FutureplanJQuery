// JSON 데이러
var tableData = [
    { "Num": "1", "Name": "홍길동", "Title": "안녕" },
    { "Num": "2", "Name": "백두산", "Title": "방가" },
    { "Num": "3", "Name": "임꺽정", "Title": "또봐" }
];

var htmls = '';

htmls += "<table border='1'>";
htmls += "<tr><th>번호</th><th>이름</th><th>제목</th>";
$.each(tableData, function () {
    htmls += "<tr>";
    htmls += "<td>" + this['Num'] + "</td>";
    htmls += "<td>" + this['Name'] + "</td>";
    htmls += "<td>" + this['Title'] + "</td>";
    htmls += "</tr>";
});
htmls += "</table>";

$('#ctlGrid').html(htmls);      //ctlGrid는 포함될 HTML에 있는 레이어
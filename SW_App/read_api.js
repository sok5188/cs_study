var request = require('request');


// var url = 'http://apis.data.go.kr/1192000/service/OceansBeachInfoService1/getOceansBeachInfo1';
// var queryParams = '?' + encodeURIComponent('serviceKey') + `=jjOIt%2BBRRquqeoegtI4DZJEZ8ezCL3xzfNUdadQDVBaEEhZodSbVfMOlSChI%2FvDUKvvmRldO1BYPvgG6jh1tOg%3D%3D
// `; /* Service Key*/
// queryParams += '&' + encodeURIComponent('pageNo') + '=' + encodeURIComponent('1'); /* */
// queryParams += '&' + encodeURIComponent('numOfRows') + '=' + encodeURIComponent('10'); /* */
// queryParams += '&' + encodeURIComponent('SIDO_NM') + '=' + encodeURIComponent('제주'); /* */
// queryParams += '&' + encodeURIComponent('resultType') + '=' + encodeURIComponent('xml'); /* */

// request({
//     url: url + queryParams,
//     method: 'GET'
// }, function (error, response, body) {
//     //console.log('Status', response.statusCode);
//     //console.log('Headers', JSON.stringify(response.headers));
//     //console.log('Reponse received', body);
//     //console.log(response);
//     console.log(body);
// });



var url = 'http://apis.data.go.kr/1360000/BeachInfoservice/getVilageFcstBeach';
var queryParams = '?' + encodeURIComponent('serviceKey') + `=jjOIt%2BBRRquqeoegtI4DZJEZ8ezCL3xzfNUdadQDVBaEEhZodSbVfMOlSChI%2FvDUKvvmRldO1BYPvgG6jh1tOg%3D%3D`;
queryParams += '&' + encodeURIComponent('pageNo') + '=' + encodeURIComponent('1'); /* */
queryParams += '&' + encodeURIComponent('numOfRows') + '=' + encodeURIComponent('10'); /* */
queryParams += '&' + encodeURIComponent('beach_num') + '=' + encodeURIComponent('304'); /* */
queryParams += '&' + encodeURIComponent('base_date') + '=' + encodeURIComponent('20220808'); /* */
queryParams += '&' + encodeURIComponent('base_time') + '=' + encodeURIComponent('0900'); /* */
queryParams += '&' + encodeURIComponent('dataType') + '=' + encodeURIComponent('xml'); /* */
console.log(url+queryParams);
request({
    url: url + queryParams,
    method: 'GET'
}, function (error, response, body) {
    console.log("Second ~~~~");
    console.log(body);
});
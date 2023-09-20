let ftpRoot = "https://arikehcarpet.com";
// ajax function for retrive special step and other request
function ajaxFunc(url, model, type, callback, error) {
    ajaxFunc(url, model, type, callback, error, true);
}
// ajax function for retrive special step and other request
function ajaxFunc(url, model, type, callback, error, async) {
    $.ajax({
        type: type,
        //beforeSend: function (xhr) {
        //    xhr.setRequestHeader("RequestVerificationToken",
        //        $('input:hidden[name="__RequestVerificationToken"]').val());
        //},
        url: url,
        dataType: "json",
        data: model,
        success: callback,
        error: error,
        async: async
    });
}

function successToastify(text) {
    $("#text-toastify-success").text(text);
    Toastify({
        node: $("#success-notification-content").clone().removeClass("hidden")[0],
        duration: 3000,
        newWindow: true,
        close: true,
        gravity: "top",
        position: "right",
        stopOnFocus: true
    }).showToast();
}

function dangerToastify(text) {
    $("#text-toastify-error").text(text);
    Toastify({
        node: $("#failed-notification-content").clone().removeClass("hidden")[0],
        duration: 3000,
        newWindow: true,
        close: true,
        gravity: "top",
        position: "right",
        stopOnFocus: true
    }).showToast();
}

let loadingBox = ` <div class="m-auto" id="box-loading-ai" style="display:none">
                                    <div class="intro-y col-span-12 sm:col-span-12 md:col-span-12 2xl:col-span-12">
                                        <div class="col-span-12 sm:col-span-12 xl:col-span-12 flex flex-col justify-end items-center">
                                            <svg width="30" viewBox="0 0 45 45" xmlns="http://www.w3.org/2000/svg" stroke="rgb(45, 55, 72)" class="w-8 h-8">
                                                <g fill="none" fill - rule="evenodd" transform="translate(1 1)" stroke - width="3">
                                                    <circle cx="22" cy="22" r="6" stroke - opacity="0">
                                                        <animate attributeName="r" begin="1.5s" dur="3s" values="6;22" calcMode="linear" repeatCount="indefinite"> </animate>
                                                        <animate attributeName="stroke-opacity" begin="1.5s" dur="3s" values="1;0" calcMode="linear" repeatCount="indefinite"> </animate>
                                                        <animate attributeName="stroke-width" begin="1.5s" dur="3s" values="2;0" calcMode="linear" repeatCount="indefinite"> </animate>
                                                    </circle>
                                                    <circle cx="22" cy="22" r="6" stroke - opacity="0">
                                                        <animate attributeName="r" begin="3s" dur="3s" values="6;22" calcMode="linear" repeatCount="indefinite"> </animate>
                                                        <animate attributeName="stroke-opacity" begin="3s" dur="3s" values="1;0" calcMode="linear" repeatCount="indefinite"> </animate>
                                                        <animate attributeName="stroke-width" begin="3s" dur="3s" values="2;0" calcMode="linear" repeatCount="indefinite"> </animate>
                                                    </circle>
                                                    <circle cx="22" cy="22" r="8">
                                                        <animate attributeName="r" begin="0s" dur="1.5s" values="6;1;2;3;4;5;6" calcMode="linear" repeatCount="indefinite"> </animate>
                                                    </circle>
                                                </g>
                                            </svg>
                                        </div>
                                    </div>
                                </div>
`;
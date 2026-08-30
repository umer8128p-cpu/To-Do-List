// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

const nav = document.querySelector(".main-nav");

const updateNavState = () => {
    if (!nav) {
        return;
    }

    nav.classList.toggle("main-nav-scrolled", window.scrollY > 10);
};

updateNavState();
window.addEventListener("scroll", updateNavState);









///////user dashboard  js

////// dark theme toggle

$(document).ready(function () {


   

    console.log("hello world")


    $('.bttn-dark').click(function () {

        $('.bttn-dark').addClass('active-dark');
        $('.bttn-light').removeClass('active-light');
        $('.bttn-light').addClass('text-light');
        $('body').addClass('dark-theme');
        $('.sidebar').addClass('dark-theme');
        $('.sidebar').addClass('dark-scroller');

    })


    $('.bttn-light').click(function () {
        $('.bttn-light').addClass('active-light');
        $('.bttn-dark').removeClass('active-dark');
        $('body').removeClass('dark-theme');
        $('.sidebar').removeClass('dark-theme');
        $('.sidebar').removeClass('dark-scroller');

    })


















    $(function () {
        const datepicker = $("#datepicker");
        const dateTarget = datepicker.data("dateTarget");

        if (datepicker.length) {
            if (dateTarget) {
                datepicker.datepicker({
                    dateFormat: "mm/dd/yy",
                    altField: dateTarget,
                    altFormat: "yy-mm-dd"
                });

                const hiddenValue = $(dateTarget).val();
                if (hiddenValue) {
                    datepicker.datepicker("setDate", hiddenValue);
                } else {
                    const visibleValue = datepicker.val();
                    if (visibleValue) {
                        datepicker.datepicker("setDate", visibleValue);
                    }
                }
            } else {
                datepicker.datepicker();
            }
        }

        $("#datepickerIcon, .calendar-trigger").on("click", function () {
            datepicker.datepicker("show");
        });
    });













    //// dropdown for category
    // open dropdown
    $(".category-btn").click(function (e) {
        e.stopPropagation();
        $(".category-options").toggle();
    });

    // select option
    $(".category-option").click(function () {

        var value = $(this).data("value");
        var text = $(this).text().trim();

        // update button UI
        $(".category-btn .text").text(text);

        // 🔥 set hidden input value
        $("#categoryValue").val(value);

        $(".category-options").hide();
    });




















    /// dropdown for priority

    // open dropdown
    $(".priority-btn").click(function (e) {
        e.stopPropagation();
        $(".priority-options").toggle();
    });

    // select option
    $(".priority-option").click(function () {

        var flag = $(this).data("flag");
        var value = $(this).data("value");

        // update button UI
        $(".priority-btn .flag").text(flag);
        $(".priority-btn .text").text(value);

        // 🔥 set hidden input value
        $("#priorityValue").val(value);

        $(".priority-options").hide();
    });

    // close outside click
    $(document).click(function () {
        $(".priority-options").hide();
        $(".category-options").hide();
    });

    const currentCategoryValue = $("#categoryValue").val();
    if (currentCategoryValue) {
        const currentCategory = $(`.category-option[data-value="${currentCategoryValue}"]`).first();
        if (currentCategory.length) {
            $(".category-btn .text").text(currentCategory.text().trim());
        }
    }

    const currentPriorityValue = $("#priorityValue").val();
    if (currentPriorityValue) {
        const currentPriority = $(`.priority-option[data-value="${currentPriorityValue}"]`).first();
        if (currentPriority.length) {
            $(".priority-btn .flag").text(currentPriority.data("flag"));
            $(".priority-btn .text").text(currentPriority.text().trim());
        }
    }



    ////////today's task filter option for category
   
        const ucfItems = document.querySelectorAll('.ucf-item');
        const ucfBtn = document.getElementById('ucfCategoryBtn');

    ucfItems.forEach(item => {
            item.addEventListener('click', function () {

                ucfItems.forEach(i => i.classList.remove('active'));
                this.classList.add('active');

                ucfBtn.innerText = this.innerText;
            });
    });
    

    ////////today's task filter option for task-status

    const ucfStatus = document.querySelectorAll('.ucf-status');
    const ucfStatusBtn = document.getElementById('ucfStatusBtn');

    ucfStatus.forEach(item => {
        item.addEventListener('click', function () {

            ucfStatus.forEach(i => i.classList.remove('active'));
            this.classList.add('active');

            ucfStatusBtn.innerText = this.innerText;

        });

// Sidebar toggle logic (vanilla + jQuery hybrid)
(function () {
    const $sidebar = $('#sidebar');
    const $overlay = $('.sidebar-overlay');

    function openSidebar() {
        $sidebar.addClass('is-open');
        $overlay.addClass('is-visible');
        $('body').addClass('no-scroll');
    }

    function closeSidebar() {
        $sidebar.removeClass('is-open');
        $overlay.removeClass('is-visible');
        $('body').removeClass('no-scroll');
    }

    $(document).on('click', '.sidebar-toggle', function (e) {
        e.preventDefault();
        openSidebar();
    });

    $(document).on('click', '.sidebar-close', function (e) {
        e.preventDefault();
        closeSidebar();
    });

    $overlay.on('click', function () {
        closeSidebar();
    });

    $(document).on('keyup', function (e) {
        if (e.key === 'Escape') {
            closeSidebar();
        }
    });

    // Prevent body scroll when sidebar open on mobile
    const observer = new MutationObserver(() => {
        if ($('body').hasClass('no-scroll')) {
            document.documentElement.style.overflow = 'hidden';
        } else {
            document.documentElement.style.overflow = '';
        }
    });
    observer.observe(document.body, { attributes: true, attributeFilter: ['class'] });
})();
    });



    $("#deleteTask").click(function (e) {

        if (!confirm("Do you want to delete this task?")) {
            e.preventDefault();
        } 
      


    })

   





});






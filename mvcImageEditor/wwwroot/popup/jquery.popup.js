// Enables background cover:  background: true, (false)
// Closes the popup when Escape key is pressed:  escClose: true, (false)
// Centers the modal window:  center : true, (false)
// The appearance of the modal window from the top (left, right, bottom): appearance: 'top' ('left' | 'right' | 'bottom')

;(function($){

    var defaults = {
        background: false,
        center: true,
        escClose: true,
        appearance: 'top',
    };

    function Popup(element, options) {
        var widget = this;
        widget.config = $.extend({}, defaults, options);
        widget.element = element;

        widget.init();
    }

    Popup.prototype.init = function() {
        
        var show = this.show.bind(this);
        var hide = this.hide.bind(this);
        var esc = this.config.escClose;
        var obj = {
            "key": esc
        };
        
        this.element.on('click', function() {    
            show();
            return false;
        });

        $(".js__p_body").on("click", function() {
            hide();
        });

        $('.js__p_close').on("click", function() {
            hide();
            return false;
        });

        this.element.keyup(obj, function(e) {
            if (e.keyCode === 27 && obj.key) {
                hide();
            } 
        });
    }

    Popup.prototype.show = function() {
        var appearance = this.config.appearance;
        var background = this.config.background;
        var center = this.config.center;

        $('body').css('overflow-y', 'hidden');

        if (!center) {
            $(".js__popup").css(appearance, '50%');

            if (appearance === 'right') {
                $(".js__popup").css({appearance: '50%', 'left': 'auto'});
            } else if (appearance === 'bottom') {
                $(".js__popup").css({appearance: '50%', 'top': 'auto'});
            }

            $(".js__popup").addClass(appearance);
        } 

        if (background) {
            $(".js__p_body").removeClass("js__fadeout");
        }

        $(".js__popup").removeClass("js__slide_top");
    }

    Popup.prototype.hide = function() {
        var appearance = this.config.appearance;

        $('body').css('overflow-y', 'auto');

        $(".js__popup").css(appearance, '');
        $(".js__popup").removeClass(appearance);
 
        $(".js__p_body").addClass("js__fadeout");
        $(".js__popup").addClass("js__slide_top");
    }

    $.fn.popup = function (options){
        new Popup(this.first(), options);
        return this.first();
    }; 
})(jQuery);
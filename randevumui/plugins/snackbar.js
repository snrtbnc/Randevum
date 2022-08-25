import Vue from 'vue'
Vue.mixin({
    methods: {

        ShowSnackBar(color, text, timeout = 500,position) {
            console.log("show sanck")
            this.$store.commit("setSnackbarInfo", {
                "color": color,
                "text": text,
                "value": true,
                "timeout": timeout,
                [position]:true

            })

        },
        HideSnackBar() {
            console.log("show sanck")
            this.$store.commit("setSnackbarInfo", {
                "value": false,
            })

        }
    }
})
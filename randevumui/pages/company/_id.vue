<template>
  <h1> MY ID :{{id}}</h1>
</template>

<script lang="ts">
import Vue from 'vue'
export default Vue.extend({
    data() {
        return {
            id:''
        }
    },

    created () {
        this.id=  this.$route.params.id;
    },
})
</script>
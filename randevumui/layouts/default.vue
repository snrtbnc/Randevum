<template>
<div>
  <nuxt/>
  <appfooter/>
  <login/>
</div>
 
</template>
<script lang="ts">
import Vue from 'vue'
import login from "../components/login.vue";
import appfooter from "../components/footer.vue";


export default Vue.extend({
   components: {
      login,
      appfooter
   },
  
})
</script>
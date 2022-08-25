<template>
  <v-footer dark padless>
    <v-card class="flex" flat tile>
      <v-card-text class="py-2 white--text text-center">
        © Copyright 2020 —
        <strong>Randevum</strong>
        <a href="mailto:info@randevum.net" style="float: right;color: inherit;"> info@randevum.net </a>
      </v-card-text>
    </v-card>
    <v-snackbar
      v-model="snackbarInfo.value"
      :timeout="snackbarInfo.timeout"
      :color="snackbarInfo.color"
      :bottom="snackbarInfo.bottom"
      :left="snackbarInfo.left"
      :top="snackbarInfo.top"
    >
      {{ snackbarInfo.text}}
    </v-snackbar>
  </v-footer>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  data: () => ({
    icons: ["mdi-facebook", "mdi-twitter", "mdi-linkedin", "mdi-instagram"]
  }),
  computed: {
    snackbarInfo() {
      return this.$store.state.snackbarInfo;
    }
  }
});
</script>
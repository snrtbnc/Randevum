<template>
  <v-app id="inspire">
    <v-app-bar :clipped-left="$vuetify.breakpoint.lgAndUp" app color="blue darken-3" dark>
      <v-toolbar-title style="width: 300px" class="ml-0 pl-4">
        <span class="hidden-sm-and-down" v-if="userInfo.isloggedin">{{userInfo.name}}</span>
      </v-toolbar-title>
      <v-text-field
        flat
        solo-inverted
        hide-details
        prepend-inner-icon="mdi-magnify"
        label="Search"
        v-model="searchValue"
      />
      <v-spacer />
      <v-btn icon @click="openLogin">Login</v-btn>
    </v-app-bar>
    <v-content>
      <v-container class="fill-height" fluid>
        <v-row align="center" justify="center">
          <nuxt />
        </v-row>
      </v-container>
      <login />
    </v-content>
    <appfooter/>
  </v-app>
</template>

<script>
import appfooter from "../components/footer.vue";
import login from "@/components/login.vue";
import { mapGetters } from "vuex";
export default {
  name: "searchpage",
  props: {
    source: String
  },
  data: () => ({
    searchValue: "",
    dialog: false,
    drawer: null
  }),
  components: {
    login,
    appfooter
  },

  watch: {
    searchValue(newValue) {
      this.$store.commit("SetSearchValue", newValue);
    }
  },
  methods: {
    openLogin() {
      this.$store.commit("setloginDialog", true);
    }
  },
  computed: {
    ...mapGetters(["userInfo"])
  }
};
</script>
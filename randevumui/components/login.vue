<template>
  <v-row justify="center" data-app>
    <v-dialog v-model="loginDialog" persistent max-width="600px">
      <v-card>
        <v-card-text>
          <v-container>
            <v-row v-if="signin">
              <v-col cols="12">
                <v-text-field label="Email*" required v-model="email"></v-text-field>
              </v-col>
              <v-col cols="12">
                <v-text-field label="Password*" type="password" required v-model="password"></v-text-field>
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>

        <v-card-actions>
          <v-btn @click="login">Login</v-btn>
          <v-btn @click="close">Close</v-btn>
        </v-card-actions>
        <v-col>
          <facebooklogin />
        </v-col>
      </v-card>
    </v-dialog>
  </v-row>
</template>
<script lang="ts">
import Vue from "vue";
import facebooklogin from "../components/facebooklogin.vue";
import { mapGetters } from "vuex";

export default Vue.extend({
  components: {
    facebooklogin
  },
  data() {
    return {
      signin: true,
      email: "",
      password: ""
    };
  },
  computed: {
    ...mapGetters(["loginDialog"])
  },
  methods: {
    async login() {
      try {
        var result = await this.$axios.post("api/auth/login", {
          email: this.email,
          password: this.password
        });

        this.$store.commit("setloginDialog", result.data);
      } catch ({ response }) {
        return;
      }

      console.log(result);
      if (result.status === 200) {
        this.$store.commit("setToken", result.data.token);
      }
      this.$store.commit("setloginDialog", false);

      if (this.$store.state.user.role == "superadmin") {
        this.$router.push("/superadmin");
      }
    },
    close() {
      this.$store.commit("setloginDialog", false);
    }
  }
});
</script>
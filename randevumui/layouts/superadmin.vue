
<template>
  <v-app id="inspire">
    <v-navigation-drawer
      v-model="drawer"
      app
    >
      <v-list dense>
        <v-list-item link>
          <v-list-item-action>
            <v-icon>mdi-home</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <nuxt-link to="/superadmin"> <v-list-item-title>Register New Company</v-list-item-title></nuxt-link>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link>
          <v-list-item-action>
            <v-icon>mdi-contact-mail</v-icon>
          </v-list-item-action>
          <v-list-item-content>
              <nuxt-link to="/superadmin/otheradminpage"> <v-list-item-title>other admin page</v-list-item-title></nuxt-link>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-app-bar
      app
      color="indigo"
      dark
    >
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
      <v-toolbar-title>Super Admin Panel</v-toolbar-title>
    </v-app-bar>

    <v-content>
      <v-container
        class="fill-height"
        fluid
      >
        <v-row
          align="center"
          justify="center"
        >
          <v-col class="text-center">
         
              <nuxt/>
         
          </v-col>
        </v-row>
        
      </v-container>
      <appfooter/>
    </v-content>
    
  </v-app>
  
</template>
<script lang="ts">
import appfooter from "../components/footer.vue";
import Vue from 'vue'
export default Vue.extend({
   props: {
      source: String,
    },
  components: {
    appfooter
  },
    data: () => ({
      drawer: null,
    }),
})
</script>
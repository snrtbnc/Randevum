<template>
 <nuxt-link  :to="{name :'company-id', params: { id:companyInfo.id }}">
  <v-card max-width="344" class="mx-auto">
    <v-list-item>
      <v-list-item-content>
        <v-list-item-title class="headline">{{companyInfo.name}}</v-list-item-title>
      </v-list-item-content>
    </v-list-item>

    <v-img  :src="companyInfo.pictureUrl" height="194"></v-img>

    <v-card-text>{{companyInfo.shortDesc}}</v-card-text>
  
    <v-card-actions>
      <v-btn text color="deep-purple accent-4" @click.prevent="doThis" >Randevu AL</v-btn>
      <v-spacer></v-spacer>
      <v-btn text color="deep-purple accent-4" v-if="companyInfo.address"  @click.prevent="goDirection(companyInfo.address.location)">GİT</v-btn>
      
    </v-card-actions>
  </v-card>
  </nuxt-link>
</template>


<script lang="ts">
import Vue, { PropOptions } from "vue";
import { company } from "../Types/companyType"
import { location } from "../Types/companyType";
export default Vue.extend({
  props: {
    companyInfo:<PropOptions<company>>{}
  },
  methods: {
    goDirection(companyLocation:location) {
     console.log(companyLocation)
    window.open(
          "maps://maps.google.com/maps?daddr="+companyLocation.latitude+","+companyLocation.longitude+"&amp;ll=",
          "_blank"
        );
      return;
    }
  },
});
</script>
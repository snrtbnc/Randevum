<template>
  <v-item-group>
    <v-container>
      <v-row v-if="CompanyList.length> 0">
        <v-pagination v-model="page" :length="(CompanyList.length /12 |0) +1"></v-pagination>
        <v-col v-for="Company in PageResult" :key="Company.Id" >
          <v-item>
            <CompanyComponent :companyInfo="Company" />
          </v-item>
        </v-col>
      </v-row>
    </v-container>
  </v-item-group>

</template>

<script  lang="ts">

import Vue, { PropOptions } from "vue";
import { company } from "../Types/companyType";

import CompanyComponent from "../components/company.vue";

export default Vue.extend({
  
  layout: "searchpage",

 components: {
    CompanyComponent,
  },

  data() {
    return {
      page: 1,
      pageLength: 0,
      testValue:{}
    };
  },
  

  async asyncData(context) {

      if(context.store.state.CompanyList.length != 0){
        return;
      }
    let companyList: Array<company> = await context.$axios.$get(
      "api/Company/companylist"
    );
    console.log(companyList)
    context.store.commit("setCompanyList", companyList);
  },

  watch: {
    page() {
      this.$store.commit("setPage", this.page);
    }
  },
  computed: {
    CompanyList() {
      return this.$store.getters.CompanyList;
    },
    PageResult() {
      return this.$store.getters.PageResult;
    }
  },
  
});
</script>

<style>
</style>

<template>
  <v-stepper v-model="e1" non-linear>
    <v-stepper-header>
      <v-stepper-step editable step="1">Genel</v-stepper-step>

      <v-divider></v-divider>

      <v-stepper-step editable step="2">İletişim</v-stepper-step>

      <v-divider></v-divider>

      <v-stepper-step editable step="3">Lokasyon</v-stepper-step>
    </v-stepper-header>

    <v-stepper-items>
      <v-stepper-content step="1">
        <v-text-field
          v-model="name"
          :error-messages="nameErrors"
          :counter="100"
          label="Firma İsmi"
          required
          @input="$v.name.$touch()"
          @blur="$v.name.$touch()"
        ></v-text-field>
        <v-text-field
          v-model="shortdesc"
          :error-messages="nameErrors"
          :counter="100"
          label="Kısa Açıklama"
          required
          @input="$v.name.$touch()"
          @blur="$v.name.$touch()"
        ></v-text-field>

        <photoUpload v-on:imageset="imageSet" />

        <v-btn color="primary" @click="e1 = 2">Devam</v-btn>
      </v-stepper-content>

      <v-stepper-content step="2">
        <v-card class="mb-12" color="grey lighten-1" height="200px"></v-card>

        <v-btn color="primary" @click="e1 = 3">Devam</v-btn>
      </v-stepper-content>

      <v-stepper-content step="3">
        <locationPicker v-on:location="locationSet" />
        <v-btn color="primary" @click="submit">Kayıt Et</v-btn>
      </v-stepper-content>
    </v-stepper-items>
  </v-stepper>
</template>

<script lang="ts">
import Vue from "vue";
import { validationMixin } from "vuelidate";
import { required, maxLength, email } from "vuelidate/lib/validators";
import { company } from "../../Types/companyType";
import photoUpload from "../../components/photo-upload.vue";
import locationPicker from "../../components/location-picker.vue";

export default Vue.extend({
  layout: "superadmin",
  mixins: [validationMixin],
  components: {
    photoUpload,
    locationPicker
  },
  validations: {
    name: { required, maxLength: maxLength(100) }
  },
  data() {
    return {
      company: {},
      name: "",
      email: "",
      shortdesc: "",
      select: null,
      checkbox: false,
      e1: 1,
      hasImage: false,
      image: null,
      location: null,
      formDataforImage: null as FormData
    };
  },

  computed: {
    nameErrors() {
      const errors = [];
      if (!this.$v.name.$dirty) return errors;
      !this.$v.name.maxLength &&
        errors.push(
          "Name must be at most " +
            this.$v.name.$params.maxLength.max +
            " characters long"
        );
      !this.$v.name.required && errors.push("Name is required.");
      return errors;
    }
  },
  methods: {
    async submit() {
      if (this.$v.$anyError) {
        this.checkErrorStep();
        return;
      }

      this.company = await this.fillCompanyInfo();
      await this.SaveCompany(this.company);

      this.ShowSnackBar("blue", this.company.name + " Added", 500, "top");
    },

    async SaveCompany(company: company) {
      try {
        var result = await this.$axios.post("api/company/add", company);
        console.log(result);
      } catch (error) {
        console.log(error);
      } finally {
        this.inProcess = false;
      }
      return result.data;
    },
    async fillCompanyInfo() {
      return (this.company = {
        name: this.name,
        shortdesc: this.shortdesc,
        pictureurl: await this.uploadImage(),
        address: {
          location: {
            latitude: this.location.lat,
            longitude: this.location.lng
          }
        }
      } as company);
    },

    async uploadImage() {
      try {
        var result = await this.$axios.post(
          "api/image/uploadimage",
          this.formDataforImage,
          {
            headers: {
              "Content-Type": "multipart/form-data"
            }
          }
        );
      } catch (error) {
        console.log(error);
      } finally {
        this.inProcess = false;
      }
      return result.data;
    },

    checkErrorStep() {
      if (this.$v.name.$anyError) this.e1 = "1";
    },
    clear() {
      this.$v.$reset();
      this.name = "";
      this.email = "";
      this.select = null;
      this.checkbox = false;
    },

    locationSet(locationValue) {
      this.location = locationValue;
    },
    imageSet(imageForm) {
      this.formDataforImage = imageForm;
    }
  }
});
</script>
<style>

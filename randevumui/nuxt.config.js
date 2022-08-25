const env = require('dotenv').config();
export default {
  mode: 'universal',

  /*
  ** Headers of the page
  */
  head: {
    title: 'Randevu Al' || '',
    meta: [
      { charset: 'utf-8' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { hid: 'description', name: 'description', content: "Randevu Al" || '' }
    ],
    script: [
      { src: '/js/fb-sdk.js' }
    ],
    link: [
      { rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' }
    ]
  },
  router: {
    middleware: "auth"
  },
  /*
  ** Customize the progress-bar color
  */
  loading: { color: '#fff' },
  /*
  ** Global CSS
  */
  css: [
  ],
  /*
  ** Plugins to load before mounting the App
  */

  plugins: [
    { src: "~/plugins/snackbar.js" },
    { src: '~/plugins/auth.js' },
    { src: '~/plugins/Vuelidate' },
    { src: '~/plugins/vue-image-upload.js', mode: 'client' },
    { src: "~/plugins/google-maps", ssr: true },
    
  ],

  /*
  ** Nuxt.js dev-modules
  */
  buildModules: [
    '@nuxt/typescript-build',
  ],
  /*
  ** Nuxt.js modules
  */
  modules: [
    // Doc: https://axios.nuxtjs.org/usage
    '@nuxtjs/vuetify',
    ['@nuxtjs/google-analytics', {
      id: 'UA-156911112-1' || ''
    }],
    ['@nuxtjs/google-adsense', {
      id: 'ca-pub-8757037019320327'
    }],
    '@nuxtjs/axios',
  ],

  /*
  ** Axios module configuration
  ** See https://axios.nuxtjs.org/options
  */
  axios: {
    proxy: true
  },

  proxy: {
    '/api/': 'http://localhost:5000' || process.env.APIURL,
  },

  /*
  ** Build configuration
  */
  build: {
    transpile: [/^vue2-google-maps-withscopedautocomp($|\/)/],
    /*
    ** You can extend webpack config here
    */
    extend(config, ctx) {
    }
  }
}


// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  compatibilityDate: '2025-07-15',
  devtools: { enabled: true },
  modules: [
    '@nuxt/eslint',
    '@nuxtjs/i18n',
    '@nuxt/fonts',
    '@nuxtjs/seo',
    '@nuxt/icon',
    '@vee-validate/nuxt',
    '@vueuse/nuxt',
    '@nuxtjs/tailwindcss',
    'shadcn-nuxt',
  ],
  i18n: {
    locales: [{ code: 'en', name: 'English', file: 'en.json' }],
    defaultLocale: 'en',
    langDir: 'locales/',
  },
  fonts: {
    families: [
      {
        name: 'Open Sans',
        provider: 'google',
        weights: [300, 400, 500, 700, 900],
      },
    ],
  },
  css: ['~/assets/css/app.css'],
  icon: {
    serverBundle: {
      collections: ['mdi'],
    },
  },
  shadcn: {
    /**
     * Prefix for all the imported component
     */
    prefix: '',
    /**
     * Directory that the component lives in.
     * @default "./components/ui"
     */
    componentDir: './components/ui',
  },
});

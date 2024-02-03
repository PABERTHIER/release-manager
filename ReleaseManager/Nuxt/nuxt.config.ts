import svgLoader from 'vite-svg-loader'

// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  app: {
    head: {
      charset: 'utf-8',
      htmlAttrs: {
        lang: 'fr',
      },
      link: [{ rel: 'icon', type: 'image/x-icon', href: '/favicon.ico' }],
      title: 'ReleaseManager',
      viewport: 'width=device-width, initial-scale=1',
    },
  },
  ssr: false,
  components: [
    {
      path: '~/components',
      pathPrefix: false,
    },
  ],
  plugins: [],
  build: {
    transpile: ['@vuepic/vue-datepicker'],
  },
  typescript: {
    strict: true,
  },
  modules: [
    '@nuxt/devtools',
    '@nuxtjs/i18n',
    '@nuxt/image',
    ['@pinia/nuxt', { autoImports: ['defineStore', 'acceptHMRUpdate'] }],
  ],
  imports: {
    dirs: ['stores'],
  },
  runtimeConfig: {
    public: {
      apiBase: 'https://localhost:7168/api',
    },
  },
  i18n: {
    defaultLocale: 'fr',
    langDir: 'lang',
    lazy: true,
    locales: [
      {
        code: 'fr',
        file: 'fr.json',
      },
    ],
  },
  vite: {
    css: {
      preprocessorOptions: {
        scss: {
          additionalData: '@import "@/styles/variables.scss";',
        },
      },
    },
    plugins: [svgLoader()],
  },
  image: {
    dir: 'assets',
  },
  devtools: {
    enabled: false,
  },
})

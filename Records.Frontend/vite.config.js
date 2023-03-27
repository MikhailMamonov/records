import { ViteMinifyPlugin } from 'vite-plugin-minify'
import { defineConfig } from 'vite'
import { resolve } from 'path';
import { viteSingleFile } from "vite-plugin-singlefile"
import vue from '@vitejs/plugin-vue'

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue(), viteSingleFile(), ViteMinifyPlugin({})],
  server: {
    port: 8080
  },
  resolve: {
    alias: [
      {
        find: '@',
        replacement: resolve(__dirname, 'src')
      }
    ]
  },
  build: {
    chunkSizeWarningLimit: 600,
    cssCodeSplit: false,
    minify: 'terser'
  }
})

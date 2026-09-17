import { defineComponent, h } from 'vue'
import DefaultTheme from 'vitepress/theme'
import { useData } from 'vitepress'
import ServerGuide from './ServerGuide.vue'
import './style.css'

export default {
  extends: DefaultTheme,
  Layout: defineComponent({
    setup() {
      const { page } = useData()
      return () => page.value.relativePath === 'index.md' ? h(ServerGuide) : h(DefaultTheme.Layout)
    }
  })
}

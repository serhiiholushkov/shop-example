import type { Config } from 'tailwindcss';

const config: Config = {
  content: [
    './app/**/*.{vue,js,ts}',
    './components/**/*.{vue,js,ts}',
    './pages/**/*.{vue,js,ts}',
    './lib/**/*.{js,ts}',
  ],
  theme: {
    extend: {},
  },
  plugins: [],
};

export default config;

<template>
  <div id="layoutContainer">
    <div id="header-container">
      <Header />
    </div>
    <div id="page-container">
      <slot />
    </div>
    <div id="footer-container">
      <Footer />
    </div>
    <div id="spotlight" />
  </div>
</template>

<style lang="scss">
@import '~/styles/default.scss';

html {
  font-family: Arial, sans-serif;
  font-size: 16px;
  word-spacing: 1px;
  -ms-text-size-adjust: 100%;
  -webkit-text-size-adjust: 100%;
  -moz-osx-font-smoothing: grayscale;
  -webkit-font-smoothing: antialiased;
  box-sizing: border-box;
  height: 100%;
  width: 100%;
  color: $primary-text-color;
}

body {
  height: 100%;
  width: 100%;
  overflow: hidden;
  margin: 0px;

  #__nuxt,
  #__layout {
    height: 100%;
    width: 100%;
    display: flex;
    flex-direction: column;
  }
}

#spotlight {
  background: linear-gradient(45deg, #00DC82 0%, #36E4DA 50%, #0047E1 100%);
  filter: blur(20vh);
  height: 40vh;
  bottom: -30vh;
  position: fixed;
  left: 0px;
  right: 0px;
  z-index: $spotlight-z-index;
}

#layoutContainer {
  height: 100vh;
  background-color: $primary-color;

  #header-container,
  #footer-container {
    background-color: $white-text-color;
    position: sticky;
    z-index: $header-z-index;
  }

  #header-container {
    top: 0;
    padding: 20px 0px;
  }

  #page-container {
    padding: 20px;
    flex: 1;
    overflow-y: auto;
    height: calc(100vh - $header-height - $footer-height - 131px);
  }

  #footer-container {
    bottom: 0;
    padding-top: 20px;
  }
}

#page-container::-webkit-scrollbar {
  width: 7px;
  border-radius: 10px;
}

#page-container::-webkit-scrollbar-track {
  border-radius: 10px;
  border: 1px solid #caca;
  background-color: #f1f1f1;
  box-shadow: inset 0 0 6px rgba(255, 255, 255, 0.3);
}

#page-container::-webkit-scrollbar-thumb {
  background: linear-gradient(45deg, #1beabd, #10abff);
  border-radius: 10px;
}
</style>

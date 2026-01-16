// Navbar Scroll Effect
window.initNavbarScroll = function () {
    const navbar = document.getElementById('mainNavbar');
    const backToTopBtn = document.getElementById('backToTop');

    if (!navbar) return;

    function handleScroll() {
        const scrolled = window.pageYOffset > 50;

        // Navbar effect
        if (scrolled) {
            navbar.classList.add('navbar-scrolled');
        } else {
            navbar.classList.remove('navbar-scrolled');
        }

        // Back to top button
        if (backToTopBtn) {
            if (window.pageYOffset > 300) {
                backToTopBtn.style.display = 'flex';
            } else {
                backToTopBtn.style.display = 'none';
            }
        }
    }

    window.addEventListener('scroll', handleScroll);
    handleScroll(); // Initial check

    // Back to top click handler
    if (backToTopBtn) {
        backToTopBtn.addEventListener('click', function () {
            window.scrollTo({
                top: 0,
                behavior: 'smooth'
            });
        });
    }
};

// Initialize on load
document.addEventListener('DOMContentLoaded', function () {
    if (typeof window.initNavbarScroll === 'function') {
        window.initNavbarScroll();
    }
});


// GLightbox instance
let lightboxInstance = null;

// Initialize GLightbox (will be called from components)
window.initGLightbox = function () {
    // Destroy previous instance if it exists
    if (lightboxInstance) {
        lightboxInstance.destroy();
    }

    // Check if GLightbox is loaded
    if (typeof GLightbox !== 'undefined') {
        lightboxInstance = GLightbox({
            touchNavigation: true,
            loop: true,
            closeButton: true,
            zoomable: true,
            autoplayVideos: true
        });
        console.log('GLightbox initialized');
        return true;
    } else {
        console.error('GLightbox library not loaded');
        return false;
    }
};


// Mobile menu close on link click
document.addEventListener('DOMContentLoaded', function () {
    const navLinks = document.querySelectorAll('.nav-link-custom');
    const navbarCollapse = document.querySelector('.navbar-collapse');

    if (navbarCollapse) {
        navLinks.forEach(link => {
            link.addEventListener('click', function () {
                if (window.innerWidth < 992) {
                    const bsCollapse = bootstrap.Collapse.getInstance(navbarCollapse);
                    if (bsCollapse) {
                        bsCollapse.hide();
                    }
                }
            });
        });
    }
});

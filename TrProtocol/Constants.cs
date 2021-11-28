namespace TrProtocol
{
    public static class Constants
    {
        [Bound("TerrariaXD230", 5044)]
        [Bound("Terraria230", 5044)]
        [Bound("Terraria233", 5087)]
        [Bound("Terraria234", 5087)]
        [Bound("Terraria235", 5087)]
        [Bound("Terraria236", 5087)]
        [Bound("Terraria237", 5087)]
        [Bound("Terraria238", 5087)]
        [Bound("Terraria242", 5124)]
        [Bound("Terraria243", 5124)]
        public static int MaxItemType { get; }
        [Bound("TerrariaXD230", 662)]
        [Bound("Terraria230", 662)]
        [Bound("Terraria233", 664)]
        [Bound("Terraria234", 664)]
        [Bound("Terraria235", 664)]
        [Bound("Terraria236", 664)]
        [Bound("Terraria237", 666)]
        [Bound("Terraria238", 667)]
        [Bound("Terraria242", 669)]
        [Bound("Terraria243", 669)]
        public static int MaxNPCID { get; }
        [Bound("TerrariaXD230", 949)]
        [Bound("Terraria230", 949)]
        [Bound("Terraria233", 953)]
        [Bound("Terraria234", 953)]
        [Bound("Terraria235", 955)]
        [Bound("Terraria236", 955)]
        [Bound("Terraria237", 955)]
        [Bound("Terraria238", 955)]
        [Bound("Terraria242", 970)]
        [Bound("Terraria243", 970)]
        public static int MaxProjectileType { get; }
        [Bound("TerrariaXD230", 622)]
        [Bound("Terraria230", 622)]
        [Bound("Terraria233", 623)]
        [Bound("Terraria234", 623)]
        [Bound("Terraria235", 623)]
        [Bound("Terraria236", 623)]
        [Bound("Terraria237", 623)]
        [Bound("Terraria238", 623)]
        [Bound("Terraria242", 624)]
        [Bound("Terraria243", 624)]
        public static int MaxTileType { get; }
        [Bound("TerrariaXD230", 322)]
        [Bound("Terraria230", 322)]
        [Bound("Terraria233", 329)]
        [Bound("Terraria234", 329)]
        [Bound("Terraria235", 329)]
        [Bound("Terraria236", 329)]
        [Bound("Terraria237", 329)]
        [Bound("Terraria238", 329)]
        [Bound("Terraria242", 335)]
        [Bound("Terraria243", 335)]
        public static int MaxBuffType { get; }

        public static readonly bool[] tileFrameImportant = Create(624, true, 3, 4, 5, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 24, 26, 27, 28, 29, 31, 33, 34, 35, 36, 42, 49, 50, 55, 61, 71, 72, 73, 74, 77, 78, 79, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 110, 113, 114, 125, 126, 128, 129, 132, 133, 134, 135, 136, 137, 138, 139, 141, 142, 143, 144, 149, 165, 171, 172, 173, 174, 178, 184, 185, 186, 187, 201, 207, 209, 210, 212, 215, 216, 217, 218, 219, 220, 227, 228, 231, 233, 235, 236, 237, 238, 239, 240, 241, 242, 243, 244, 245, 246, 247, 254, 269, 270, 271, 275, 276, 277, 278, 279, 280, 281, 282, 283, 285, 286, 287, 288, 289, 290, 291, 292, 293, 294, 295, 296, 297, 298, 299, 300, 301, 302, 303, 304, 305, 306, 307, 308, 309, 310, 314, 316, 317, 318, 319, 320, 323, 324, 334, 335, 337, 338, 339, 349, 354, 355, 356, 358, 359, 360, 361, 362, 363, 364, 372, 373, 374, 375, 376, 377, 378, 380, 386, 387, 388, 389, 390, 391, 392, 393, 394, 395, 405, 406, 410, 411, 412, 413, 414, 419, 420, 423, 424, 425, 427, 428, 429, 435, 436, 437, 438, 439, 440, 441, 442, 443, 444, 445, 452, 453, 454, 455, 456, 457, 461, 462, 463, 464, 465, 466, 467, 468, 469, 470, 471, 475, 476, 480, 484, 485, 486, 487, 488, 489, 490, 491, 493, 494, 497, 499, 505, 506, 509, 510, 511, 518, 519, 520, 521, 522, 523, 524, 525, 526, 527, 529, 530, 531, 532, 533, 538, 542, 543, 544, 545, 547, 548, 549, 550, 551, 552, 553, 554, 555, 556, 558, 559, 560, 564, 565, 567, 568, 569, 570, 571, 572, 573, 579, 580, 581, 582, 583, 584, 585, 586, 587, 588, 589, 590, 591, 592, 593, 594, 595, 596, 597, 598, 599, 600, 601, 602, 603, 604, 605, 606, 607, 608, 609, 610, 611, 612, 613, 614, 615, 616, 617, 619, 620, 621, 622, 623);
        private static T[] Create<T>(int count, T nonDefaultValue, params int[] indexes)
        {
            var result = new T[count];
            foreach (var item in indexes)
            {
                result[item] = nonDefaultValue;
            }
            return result;
        }
    }
}
